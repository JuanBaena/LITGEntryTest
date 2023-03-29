using UnityEngine;
using Zenject;

public class WeaponView : MonoBehaviour, IWeaponView
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private Transform weaponShootOutput;


    [Inject(Id = "firstPersonPlayerView")]
    private IPlayerView playerView;

    private bool _isReloading;
    private int _bulletsLeft;
    private AudioSource _audioSource;

    private void Start()
    {
        resetWeaponData();
        _audioSource = this.GetComponent<AudioSource>();
    }
    private void resetWeaponData()
    {
        _bulletsLeft = weaponData.MagazineSize;
    }
    public void shoot()
    {
        if (_bulletsLeft <= 0) return;

        // Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(weaponData.Bullet, weaponShootOutput.position, Quaternion.identity);

        // AddForce
        currentBullet.GetComponent<Rigidbody>()
            .AddForce(playerView.getCamera().transform.forward * weaponData.FowardForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>()
            .AddForce(playerView.getCamera().transform.up * weaponData.UpwardForce, ForceMode.Impulse);

        // Activate bullet
        //CustomProjectiles customProjectiles = currentBullet.GetComponent<CustomProjectiles>();
        //if (customProjectiles) customProjectiles.activated = true;

        // Instantiate Flash effect
        Instantiate(weaponData.MuzzleFlash, weaponShootOutput.position, Quaternion.identity);

        // Add Sound
        _audioSource.PlayOneShot(weaponData.ShootSound);

        // Update bullets
        _bulletsLeft--;
    }
    public void reload()
    {
        resetWeaponData();
    }

    #region Getters
    public int getBulletsLeft()
    {
        return _bulletsLeft;
    }

    public int getMagazineSize()
    {
        return weaponData.MagazineSize;
    }
    #endregion

}
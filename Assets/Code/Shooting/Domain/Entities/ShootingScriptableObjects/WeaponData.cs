using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 2)]
public class WeaponData : ScriptableObject
{ 
    [Header("Prefabs")]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private AudioClip shootSound;

    [Header("Shoot properties")]
    [SerializeField]
    private float fowardForce;
    [SerializeField]
    private float upwardForce;

    [Header("Capacity properties")]
    [SerializeField]
    private int magazineSize;

    public GameObject Bullet
    {
        get => bullet;
    }
    public GameObject MuzzleFlash
    {
        get => muzzleFlash;
    }
    public AudioClip ShootSound
    {
        get => shootSound;
    }
    public float FowardForce
    {
        get => fowardForce;
    }
    public float UpwardForce
    {
        get => upwardForce;
    }
    public int MagazineSize
    {
        get => magazineSize;
    }
}
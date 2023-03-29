using UnityEngine;
using Zenject;

class ShootingUseCases : MonoBehaviour, IWeaponUseCases, IPlayerMovementUseCases
{
    [Inject]
    IPlayerPreferences playerPreferences;
    [Inject(Id = "miniaturePlayerView")]
    IPlayerView miniaturePlayerView;
    [Inject(Id = "firstPersonPlayerView")]
    IPlayerView firstPersonPlayerView;
    [Inject]
    IPickingSystemController pickingSystemController;
    [Inject]
    IWeaponController weaponController;
    [Inject]
    IShootingScreenPresenter shootingScreenPresenter;

    private void Start()
    {
        setAnimationPreferenceOnMiniature();
        shootingScreenPresenter.setBulletsLeftText("0");
        shootingScreenPresenter.setBulletsMagazineText("0");
    }
    private void setAnimationPreferenceOnMiniature()
    {
        miniaturePlayerView.setBodyLayerAnimation(
            playerPreferences.getAnimationPreference()
        );
    }

    public void movePlayer(Vector3 motion)
    {
        firstPersonPlayerView.setMotion(motion);
    }
    public void rotatePlayer(Vector3 eulers)
    {
        firstPersonPlayerView.setRotation(eulers);
    }

    #region Weapon

    public void reloadWeapon()
    {
        if (!pickingSystemController.isEquipped()) return;
        weaponController.reload();
        shootingScreenPresenter.setBulletsLeftText(
            weaponController.getBulletsLeft().ToString()
        );
        shootingScreenPresenter.setBulletsMagazineText(
            weaponController.getMagazineSize().ToString()
        );
    }

    public void shoot()
    {
        if (!pickingSystemController.isEquipped()) return;
        weaponController.shoot();
        shootingScreenPresenter.setBulletsLeftText(
            weaponController.getBulletsLeft().ToString()
        );
    }

    public void throwWeapon()
    {
        pickingSystemController.throwElement();
        shootingScreenPresenter.setBulletsLeftText("0");
        shootingScreenPresenter.setBulletsMagazineText("0");
    }

    public void grabWeapon()
    {
        pickingSystemController.pickUp();
        if (!pickingSystemController.isEquipped()) return;
        weaponController.updateWeapon();
        shootingScreenPresenter.setBulletsLeftText(
            weaponController.getBulletsLeft().ToString()
        );
        shootingScreenPresenter.setBulletsMagazineText(
            weaponController.getMagazineSize().ToString()
        );
    }
    #endregion
}

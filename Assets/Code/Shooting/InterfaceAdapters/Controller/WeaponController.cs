using UnityEngine;

public class WeaponController : MonoBehaviour, IWeaponController
{
    // Strategy Pattern
    private IWeaponView weaponViewContext;

    public int getBulletsLeft()
    {
        return weaponViewContext.getBulletsLeft();
    }

    public int getMagazineSize()
    {
        return weaponViewContext.getMagazineSize();
    }

    public void reload()
    {
        if (weaponViewContext != null) weaponViewContext.reload();
    }

    public void shoot()
    {
        if (weaponViewContext != null) weaponViewContext.shoot();
    }

    public void updateWeapon()
    {
        weaponViewContext = this.GetComponentInChildren<IWeaponView>();
    }
}
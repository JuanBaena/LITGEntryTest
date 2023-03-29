public interface IWeaponController
{
    void updateWeapon();
    void shoot();
    void reload();
    int getBulletsLeft();
    int getMagazineSize();
}

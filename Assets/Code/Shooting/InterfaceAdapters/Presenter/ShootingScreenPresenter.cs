using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

class ShootingScreenPresenter: MonoBehaviour, IShootingScreenPresenter
{
    [SerializeField]
    private TMP_Text bulletsLeftText;
    [SerializeField]
    private TMP_Text bulletsMagazineText;

    public void setBulletsMagazineText(string bulletsMagazineeSize)
    {
        bulletsMagazineText.text = bulletsMagazineeSize;
    }

    public void setBulletsLeftText(string bulletsLeft)
    {
        bulletsLeftText.text = bulletsLeft;
    }
}

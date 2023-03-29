using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AnimationsScreenPresenter : MonoBehaviour, IAnimationsScreenPresenter
{
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    [Inject]
    private ISelectAnimationUseCases selectAnimationUseCases;

    void Start()
    {
        continueButton.onClick.AddListener(goNextSceneCommand);
        continueButton.interactable = false;
    }
    public void activateContinueButton()
    {
        continueButton.interactable = true;
    }

    public void changeAnimationCommand(string triggerName)
    {
        audioSource.PlayOneShot(audioClip);
        selectAnimationUseCases.setPlayerAnimation(triggerName);
    }

    private void goNextSceneCommand()
    {
        selectAnimationUseCases.goShootingScene();
    }

}

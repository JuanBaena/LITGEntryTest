using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SelectAnimationUseCases : MonoBehaviour, ISelectAnimationUseCases
{
    [Inject]
    IPlayerView playerView;
    [Inject]
    IAnimationsScreenPresenter animationsScreenPresenter;
    [Inject]
    IPlayerPreferences playerPreferences;

    public void setPlayerAnimation(string triggerName)
    {
        playerPreferences.setAnimationPreference(triggerName);
        animationsScreenPresenter.activateContinueButton();
        playerView.setOriginalPlayerTransformProps();
        playerView.setBodyLayerAnimation(triggerName);
    }

    public void goShootingScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}

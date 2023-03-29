using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;
public class AnimationButtonView : MonoBehaviour
{
    [SerializeField]
    private AnimationData animationData;

    [Inject]
    private IAnimationsScreenPresenter animationsScreenPresenter;

    void Start()
    {
        this.GetComponentInChildren<TMP_Text>().text = animationData.Name;
        this.GetComponent<Button>().onClick.AddListener(animationButtonOnClick);
    }

    private void animationButtonOnClick()
    {
        animationsScreenPresenter.changeAnimationCommand(animationData.TriggerName);
    }
}

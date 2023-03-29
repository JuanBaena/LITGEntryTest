using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AnimationDataScriptableObject", order = 1)]
public class AnimationData : ScriptableObject
{
    [SerializeField]
    private string animationName;
    [SerializeField]
    private string animationTrigger;

    public string Name
    {
        get => animationName;
    }
    public string TriggerName
    {
        get => animationTrigger;
    }
}

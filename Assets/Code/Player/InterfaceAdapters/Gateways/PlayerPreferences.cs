using UnityEngine;

public class PlayerPreferences : IPlayerPreferences
{
    private const string ANIMATION_PREF_KEY = "ANIMATION_PREF_KEY";
    private string _animationPreference;

    public PlayerPreferences()
    {
        loadPreferences();
    }

    private void loadPreferences()
    {
        _animationPreference = PlayerPrefs.GetString(ANIMATION_PREF_KEY) ?? "MacarenaTrigger";
    }
    public string getAnimationPreference()
    {
        return _animationPreference;
    }

    public void setAnimationPreference(string animationPreference)
    {
        _animationPreference = animationPreference;
        PlayerPrefs.SetString(ANIMATION_PREF_KEY, _animationPreference);
    }
}

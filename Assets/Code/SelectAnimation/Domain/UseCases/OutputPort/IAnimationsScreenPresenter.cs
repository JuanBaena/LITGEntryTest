using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IAnimationsScreenPresenter
{
    void activateContinueButton();
    void changeAnimationCommand(string triggerName);
}

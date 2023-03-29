using UnityEngine;

public interface IPlayerView
{
    void setBodyLayerAnimation(string triggerName);
    void setOriginalPlayerTransformProps();
    void setMotion(Vector3 motion);
    void setRotation(Vector3 eulers);
    Camera getCamera();
}

using UnityEngine;

public class PlayerView : MonoBehaviour, IPlayerView
{
    private Animator _playerAnimator;
    private Transform _playerTransform;
    private Vector3 _playerOriginalPosition;
    private Quaternion _playerOriginalRotation;
    private CharacterController _controller;

    private const float _gravitiy = -9.8f;

    void Start()
    {
        _playerAnimator = this.GetComponent<Animator>();
        _playerTransform = this.GetComponent<Transform>();
        _controller = this.GetComponent<CharacterController>();
        _playerOriginalPosition = _playerTransform.position;
        _playerOriginalRotation = _playerTransform.rotation;
    }
    public void setBodyLayerAnimation(string triggerName)
    {
        if (!_playerAnimator) _playerAnimator = this.GetComponent<Animator>();
        _playerAnimator.SetTrigger(triggerName);
    }
    public void setOriginalPlayerTransformProps()
    {
        _playerTransform.position = _playerOriginalPosition;
        _playerTransform.rotation = _playerOriginalRotation;
    }

    public void setMotion(Vector3 motion)
    {
        motion.y += _gravitiy * Time.deltaTime;
        _controller.Move(motion);
    }

    public void setRotation(Vector3 eulers)
    {
        _playerTransform.Rotate(eulers);
    }

    public Camera getCamera()
    {
        return this.GetComponentInChildren<Camera>();
    }
}

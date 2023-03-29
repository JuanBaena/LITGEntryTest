using UnityEngine;
using Zenject;
using UniRx;

public class PlayerMouseInput : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;

    [Inject]
    IPlayerMovementUseCases playerMovementUseCases;
    [Inject]
    IWeaponUseCases weaponUseCases;

    private float _xRotation;

    // Give default vaules on Editor
    private void Reset()
    {
        mouseSensitivity = 100f;
        _xRotation = 0f;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Set click stream observable and subscribe
        var clickStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));

        clickStream.Subscribe(_ => onMouseClick());

        // Set mouse motion stream observable and subscribe
        var mouseMotionStream = Observable.EveryUpdate()
            .Select(_ =>
                new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y"))
            )
            .Where(motion => motion != Vector2.zero);

        mouseMotionStream.Subscribe(motionVector => 
            onMouseMovement(
                motionVector.x * mouseSensitivity * Time.deltaTime,
                motionVector.y * mouseSensitivity * Time.deltaTime
            )
        );
    }

    private void onMouseMovement(float mouseX, float mouseY)
    {
        // Use changes in mouse to rotate player
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerMovementUseCases.rotatePlayer(Vector3.up * mouseX);
    }

    private void onMouseClick()
    {
        weaponUseCases.shoot();
    }
}

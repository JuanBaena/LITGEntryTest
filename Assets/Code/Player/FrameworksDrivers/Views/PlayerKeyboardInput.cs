using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerKeyboardInput : MonoBehaviour
{
    [SerializeField]
    private float characterSpeed;

    [Inject]
    IPlayerMovementUseCases playerMovementUseCases;
    [Inject]
    IWeaponUseCases weaponUseCases;

    private void Reset()
    {
        characterSpeed = 8f;
    }

    private void Start()
    {
        // Set controller axis stream observable and subscribe
        var controllerAxisMotionStream = Observable.EveryUpdate()
            .Select(_ =>
                new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"))
            );

        controllerAxisMotionStream.Subscribe(motionVector =>
            onAxisMove(
                motionVector.x * characterSpeed * Time.deltaTime,
                motionVector.y * characterSpeed * Time.deltaTime
            )
        );

        // Set R stream observable and subscribe        
        var RStream = Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.R));

        RStream.Buffer(RStream.Throttle(TimeSpan.FromMilliseconds(50)))
            .Subscribe(_ => onRKeyDown());

        // Set Q stream observable and subscribe        
        var QStream = Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.Q));

        QStream.Buffer(QStream.Throttle(TimeSpan.FromMilliseconds(50)))
            .Subscribe(_ => onQKeyDown());

        // Set E stream observable and subscribe        
        var EStream = Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.E));

        EStream.Buffer(EStream.Throttle(TimeSpan.FromMilliseconds(50)))
            .Subscribe(_ => onEKeyDown());
    }

    private void onAxisMove(float x, float z)
    {
        Vector3 motion = transform.right * x + transform.forward * z;
        playerMovementUseCases.movePlayer(motion);
    }

    private void onRKeyDown()
    {
        weaponUseCases.reloadWeapon();
    }

    private void onEKeyDown()
    {
        weaponUseCases.grabWeapon();
    }

    private void onQKeyDown()
    {
        weaponUseCases.throwWeapon();
    }
}



using UnityEngine;
using System;

public class PickingSystemController : MonoBehaviour, IPickingSystemController
{
    [SerializeField]
    private Transform grabAreaTransform;
    [SerializeField]
    private float sphereRadius = 0.75f;
    [SerializeField]
    private Transform gunPlayerContainer;
    [SerializeField]
    private float dropForwardForce;
    [SerializeField]
    private float dropUpwardForce;

    private bool _isEquipped;
    private Rigidbody _equippedObjectRigidBody;
    private Transform _equippedObjectTransform;
    private Collider _equippedObjectCollider;

    private void Start()
    {
        _isEquipped = false;
    }

    public bool isEquipped()
    {
        return _isEquipped;
    }

    public void pickUp()
    {
        // Get near elements and search for Gun
        Collider[] hitColliders = Physics.OverlapSphere(
            grabAreaTransform.position,
            sphereRadius
        );

        _equippedObjectCollider = Array.Find(
            hitColliders,
            collider => collider.gameObject.tag == "Weapon"
        );

        if (!_equippedObjectCollider) return;

        _equippedObjectRigidBody = _equippedObjectCollider.gameObject.GetComponent<Rigidbody>();
        _equippedObjectTransform = _equippedObjectCollider.gameObject.GetComponent<Transform>();

        //Make Rigidbody Kinematic and BoxCollider a trigger
        _equippedObjectRigidBody.isKinematic = true;
        _equippedObjectCollider.isTrigger = true;

        //Make weapon a child of the camera and move it to the equippedPosition
        _isEquipped = true;
        _equippedObjectTransform.SetParent(gunPlayerContainer);
        _equippedObjectTransform.localPosition = Vector3.zero;
        _equippedObjectTransform.localRotation = Quaternion.Euler(Vector3.zero);
        _equippedObjectTransform.localScale = Vector3.one;
    }

    public void throwElement()
    {
        if (!_isEquipped) return;
        _isEquipped = false;
        //Set parent to null
        _equippedObjectTransform.SetParent(null);

        //Make Rigidbody and BoxCollider normal
        _equippedObjectRigidBody.isKinematic = false;
        _equippedObjectCollider.isTrigger = false;
        
        //Add force
        _equippedObjectRigidBody.AddForce(gunPlayerContainer.forward * dropForwardForce, ForceMode.Impulse);
        _equippedObjectRigidBody.AddForce(gunPlayerContainer.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = UnityEngine.Random.Range(-1f, 1f);
        _equippedObjectRigidBody.AddTorque(new Vector3(random, random, random) * 10);
    }
}

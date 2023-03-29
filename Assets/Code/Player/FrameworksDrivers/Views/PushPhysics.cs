using UnityEngine;

public class PushPhysics : MonoBehaviour
{
    // this script pushes all rigidbodies that the character touches
    [SerializeField]
    private float pushPower;

    private void Reset()
    {
        pushPower = 2.0f;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody affectedBody = hit.collider.attachedRigidbody;

        // Early return on non-existent rigidbody
        if (affectedBody == null || affectedBody.isKinematic) return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply the push
        affectedBody.velocity = pushDirection * pushPower;
    }
}
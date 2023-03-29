using UnityEngine;
public class ForceFieldProjectileView : BasicProjectileView
{
    [SerializeField]
    private ForceFieldProjectileData forceFieldProjectileData;

    protected override void Update()
    {
        base.Update();
        attractToOnRangeElements();
    }

    private void attractToOnRangeElements()
    {
        // Get on range elements
        Collider[] hitColliders = Physics.OverlapSphere(
            this.transform.position,
            forceFieldProjectileData.FieldRadius
        );
        
        // Aplly force if element has RigidBody
        foreach (Collider colliderAffected in hitColliders)
        {
            Rigidbody rigidbodyAffected = colliderAffected.gameObject.GetComponent<Rigidbody>();
            if (!rigidbodyAffected) continue;

            // Apply force
            Vector3 difference = this.transform.position 
                - colliderAffected.gameObject.GetComponent<Transform>().position;
            Vector3 forceDirection = difference.normalized;
            Vector3 forceVector = forceDirection * forceFieldProjectileData.FieldForce;
            rigidbodyAffected.AddForce(forceVector);
        }
    }

}

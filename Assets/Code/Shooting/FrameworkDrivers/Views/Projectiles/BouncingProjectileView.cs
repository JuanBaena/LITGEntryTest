using UnityEngine;
public class BouncingProjectileView : BasicProjectileView
{
    [SerializeField]
    private BouncingProjectileData bouncingProjectileData;

    private int _collisionsCounter;

    protected override void Update()
    {
        base.Update();

        // Bounce Update
        if (_collisionsCounter >= bouncingProjectileData.MaxCollisions)
        {
            Debug.Log("Exploded by maxCollisions");
            explode();
        }
    }

    protected override void Setup()
    {
        base.Setup();

        // Bounce Setup
        //Setup physics material
        PhysicMaterial _physicMaterial = new PhysicMaterial();
        _physicMaterial.bounciness = bouncingProjectileData.Bounciness;
        _physicMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
        _physicMaterial.bounceCombine = PhysicMaterialCombine.Maximum;
        //Apply the physics material to the collider
        this.GetComponent<SphereCollider>().material = _physicMaterial;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        //Count up collisions
        _collisionsCounter++;
    }
}
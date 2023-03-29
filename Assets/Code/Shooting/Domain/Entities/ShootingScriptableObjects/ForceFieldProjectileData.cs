using UnityEngine;

[CreateAssetMenu(fileName = "ForceFieldProjectileData", menuName = "ScriptableObjects/ForceFieldProjectileData", order = 5)]
public class ForceFieldProjectileData : BasicProjectileData
{
    // Field forced generator projectile
    [Header("Field forced properties")]
    [SerializeField]
    private float fieldRadius;
    [SerializeField]
    private float fieldForce;

    public float FieldRadius
    {
        get => fieldRadius;
    }
    public float FieldForce
    {
        get => fieldForce;
    }
}
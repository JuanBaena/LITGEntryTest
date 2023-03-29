using UnityEngine;

[CreateAssetMenu(fileName = "BouncingProjectileData", menuName = "ScriptableObjects/BouncingProjectileData", order = 4)]
public class BouncingProjectileData : BasicProjectileData
{
    // Bouncing projectile
    [Header("Bounciness properties")]
    [SerializeField]
    [Range(0f, 1f)]
    private float bounciness;
    [SerializeField]
    private int maxCollisions;

    public float Bounciness
    {
        get => bounciness;
    }
    public int MaxCollisions
    {
        get => maxCollisions;
    }
}
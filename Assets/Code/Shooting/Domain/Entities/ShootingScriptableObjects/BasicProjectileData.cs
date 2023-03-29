using UnityEngine;

[CreateAssetMenu(fileName = "BasicProjectileData", menuName = "ScriptableObjects/BasicProjectileData", order = 3)]
public class BasicProjectileData : ScriptableObject
{ 
    // Basic projectile
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject explosionPrefab;

    [Header("Basic properties")]
    [SerializeField]
    protected bool useGravity;
    [SerializeField]
    protected float mass;

    [Header("Lifetime properties")]
    [SerializeField]
    protected float maxLifetime;
    [SerializeField]
    protected bool explodeOnTouch;

    public GameObject ExplosionPrefab
    {
        get => explosionPrefab;
    }
    public bool UseGravity
    {
        get => useGravity;
    }
    public float Mass
    {
        get => mass;
    }
    public float MaxLifetime
    {
        get => maxLifetime;
    }
    public bool ExplodeOnTouch
    {
        get => explodeOnTouch;
    }
}

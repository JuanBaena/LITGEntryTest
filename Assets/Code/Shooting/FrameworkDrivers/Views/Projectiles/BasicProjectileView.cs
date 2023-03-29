using UnityEngine;

public class BasicProjectileView : MonoBehaviour
{
    [SerializeField]
    protected BasicProjectileData basicProjectileData;
    protected float _maxLifetime;

    private void Start()
    {
        _maxLifetime = basicProjectileData.MaxLifetime;
        Setup();
    }

    protected virtual void Update()
    {
        // General Update
        _maxLifetime -= Time.deltaTime;
        if (_maxLifetime <= 0)
        {
            Debug.Log("Exploded by maxCollisions");
            explode();
        }
    }

    protected virtual void Setup()
    {
        // General Setup
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.mass = basicProjectileData.Mass;
        rigidbody.useGravity = basicProjectileData.UseGravity;
    }

    protected void explode()
    {
        //Instantiate explosion if attatched
        if (basicProjectileData.ExplosionPrefab != null)
            Instantiate(
                basicProjectileData.ExplosionPrefab,
                this.transform.position,
                Quaternion.identity
            );

        //Invoke destruction
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<TrailRenderer>().emitting = false;
        Invoke("destroyProjectile", 0.08f);
    }
    private void destroyProjectile()
    {
        Destroy(gameObject);
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        //Explode on touch
        if (basicProjectileData.ExplodeOnTouch)
        {
            Debug.Log("Exploded by maxCollisions");
            explode();
        }
    }
}



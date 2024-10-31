using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public float explosionTimer = 3.0f;
    public float explosionRadius = 5.0f;
    public float explosionForce = 1000f;
    private bool _exploded = false;

    void Start()
    {
        Invoke("Explode",explosionTimer);
    }

    private void Explode()
    {
        if (_exploded) return;
        _exploded = true;
        Collider[] victimColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider victimCollider in victimColliders)
        {
            Rigidbody rb = victimCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce,transform.position,explosionRadius);
            }
        }
        Destroy(gameObject);
    }
}

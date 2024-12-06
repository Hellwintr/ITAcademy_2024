using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject activeAmmoPrefab;
    public Transform barrel;
    public float shootForce;

    void Start()
    {
        ZoneManager.Instance.RegisterGun(this);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject ammo = Instantiate(activeAmmoPrefab, barrel.position, barrel.rotation);
        Rigidbody rb = ammo.GetComponent<Rigidbody>();
        TrailRenderer trail = ammo.GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trail.Clear();
        }

        ammo.AddComponent<CollisionHandler>();
        rb.AddForce(barrel.forward*shootForce);
        Destroy(ammo,5f);
    }

    public void SetActiveAmmo(GameObject ammo, float force)
    {
        activeAmmoPrefab = ammo;
        shootForce = force;
    }
}
public class CollisionHandler : MonoBehaviour
{
    private GameObject collisionEffectPrefab;
   private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Снаряд столкнулся с " + collision.gameObject.name);
        CollisionEffect collisionEffect = GetComponent<CollisionEffect>();
        if (collisionEffect != null && collisionEffect.collisionEffectPrefab != null)
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 collisionNormal = collision.contacts[0].normal;
            Instantiate(collisionEffect.collisionEffectPrefab, collisionPoint, Quaternion.LookRotation(collisionNormal));
        }
    }
}


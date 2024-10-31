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
        rb.AddForce(barrel.forward*shootForce);
        Destroy(ammo,5f);
    }

    public void SetActiveAmmo(GameObject ammo, float force)
    {
        activeAmmoPrefab = ammo;
        shootForce = force;
    }
}

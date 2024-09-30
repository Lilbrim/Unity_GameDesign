using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce=200f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEff;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;


    public Camera GunCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot ()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(GunCam.transform.position, GunCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            hit.transform.GetComponent<Target>();
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody !=null)
            {
                hit.rigidbody.AddForce(-hit.normal*impactForce);
            }

            Instantiate(impactEff, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}

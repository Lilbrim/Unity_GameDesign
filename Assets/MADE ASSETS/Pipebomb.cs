using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Pipebombs : MonoBehaviour
{
    public float delay= 3f;
    public float radius=5f;
    public float impactForce=500f;
    float countdown;
    public GameObject explosionEffect;
    bool Exploded=false;
     public float damage = 40f;
    
    void Start()
    {
        countdown=delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !Exploded)
        {
            Explode();
            Exploded=true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders=Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb=nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(impactForce, transform.position, radius);
            }
            Target target = nearbyObject.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        Destroy(gameObject);

    }
}


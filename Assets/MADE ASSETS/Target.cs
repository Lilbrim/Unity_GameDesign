using UnityEngine;


public class Target : MonoBehaviour
{
    public ParticleSystem explosion;
    public float hp= 30f;
    public void TakeDamage (float amount)
    {
        hp -= amount;
        if(hp <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

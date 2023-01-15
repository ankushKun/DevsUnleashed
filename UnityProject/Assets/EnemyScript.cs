using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int issueNumber;
    public ParticleSystem deathParticles;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // Debug.Log("Collision with " + collision.gameObject.name + " at " + contact.point + " with normal " + contact.normal);
            if (collision.gameObject.name == "Bullet(FIRED)")
            {
                if (collision.gameObject.GetComponent<BulletScript>().issueNumber == issueNumber)
                {
                    Destroy(collision.gameObject);
                    deathParticles.Play();
                    // Destroy(gameObject, 0.51f);
                }
            }
        }
        // if (collision.relativeVelocity.magnitude > 2)
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int issueNumber;
    public ParticleSystem deathParticles;

    public Material disabled;

    Manager managerScript;

    GameObject manager;
    Transform target;
    Transform player;

    bool dead = false;

    public float speed = 1.0f;
    void Start()
    {
        manager = GameObject.Find("MANAGER");
        target = GameObject.Find("Target").transform;
        player = GameObject.Find("Player").transform;
        managerScript = manager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            // Body
            transform.LookAt(target.transform);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        // Floating name
        transform.GetChild(1).rotation = Quaternion.LookRotation(transform.position - player.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // Debug.Log("Collision with " + collision.gameObject.name + " at " + contact.point + " with normal " + contact.normal);
            if (collision.gameObject.name == "Bullet(FIRED)")
            {
                if (dead)
                {
                    deathParticles.Play();
                }
                if (collision.gameObject.GetComponent<BulletScript>().issueNumber == issueNumber)
                {
                    deathParticles.Play();
                    // Destroy(collision.gameObject);
                    gameObject.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material = disabled;
                    gameObject.transform.GetChild(0).GetChild(2).GetComponent<Renderer>().material = disabled;
                    dead = true;
                    managerScript.DecrementWatcherCount();
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
                else
                {

                }
            }
        }
    }
}

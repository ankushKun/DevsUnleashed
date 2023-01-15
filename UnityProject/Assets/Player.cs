using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject indicator;
    public GunScript gunScript;

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
            if (collision.gameObject.name == "Bullet(Clone)")
            {
                Material mat = indicator.GetComponent<Renderer>().material;
                mat.SetColor("_EmissionColor", collision.gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor"));
                gunScript.bulletIssueNumber = collision.gameObject.GetComponent<BulletScript>().issueNumber;
                gunScript.GetComponent<GunScript>().hasBullet = true;
                Destroy(collision.gameObject);
            }
        }
        // if (collision.relativeVelocity.magnitude > 2)
    }
}

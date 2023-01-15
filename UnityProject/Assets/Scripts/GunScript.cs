using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int bulletIssueNumber;
    public bool hasBullet;

    public GameObject bulletPrefab;

    public Color[] bulletColors = new Color[10];

    public Transform bulletSpawn;

    public Transform cameraTransform;
    public Transform gunJoint;

    float bulletScale = 0.314f;
    public float bulletSpeed = 1000f;

    int xMax = 20, xMin = -23, zMax = 15, zMin = -29;

    int bpos = 0;

    void Start()
    {
        hasBullet = false;
    }

    // Update is called once per frame
    void Update()
    {
        gunJoint.transform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x, cameraTransform.rotation.eulerAngles.y, 0);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fireBullet();
        }
    }

    public void fireBullet()
    {
        // if (hasBullet)
        // {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Material mat = bullet.GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", bulletColors[bulletIssueNumber]);
        bullet.GetComponent<BulletScript>().issueNumber = bulletIssueNumber;
        bullet.transform.SetParent(bulletSpawn);
        bullet.transform.localPosition = new Vector3(0, 0, 0);
        bullet.name = "Bullet(FIRED)";
        bullet.transform.SetParent(null);
        bullet.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
        bullet.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        // hasBullet = false;
        // }
    }

    public void spawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(Random.Range(xMin, xMax), 2, Random.Range(zMin, zMax)), Quaternion.identity);
        Material mat = bullet.GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", bulletColors[bpos]);
        bullet.GetComponent<BulletScript>().issueNumber = bpos;
        bpos++;
        if (bpos >= bulletColors.Length)
        {
            bpos = 0;
        }
    }
}

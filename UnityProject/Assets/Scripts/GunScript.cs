using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public float bulletSpeed = 10000f;

    public GameObject enemyPrefab;

    public GameObject indicator;
    public Material disabled;

    public int xMax = 20, xMin = -23, zMax = 15, zMin = -29;

    public int bpos = 0;

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
        if (hasBullet)
        {
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
            // bullet.GetComponent<BulletScript>().deleteIn10();
            // indicator.GetComponent<Renderer>().material = disabled;
            indicator.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            hasBullet = false;

        }
    }

    public void spawnBullet(string name)
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(Random.Range(xMin, xMax), 2, Random.Range(zMin, zMax)), Quaternion.identity);
        Material mat = bullet.GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", bulletColors[bpos]);
        bullet.GetComponent<BulletScript>().issueNumber = bpos;

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(xMin, xMax), 5, UnityEngine.Random.Range(zMin, zMax)), Quaternion.identity);
        enemy.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", bulletColors[bpos]); // brenA
        enemy.transform.GetChild(0).GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", bulletColors[bpos]); // brenB
        enemy.transform.GetChild(1).GetComponent<TMP_Text>().text = name;
        enemy.GetComponent<EnemyScript>().issueNumber = bpos;

        bpos++;
        if (bpos >= bulletColors.Length)
        {
            bpos = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int issueNumber;
    void Start()
    {
        Invoke("rename", 1f);
    }

    void rename()
    {
        gameObject.name = "Bullet(PICKUP)";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deleteIn10()
    {
        Destroy(gameObject, 10f);
    }
}

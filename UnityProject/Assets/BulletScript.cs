using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int issueNumber;
    void Start()
    {
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
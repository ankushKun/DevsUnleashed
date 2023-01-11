using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepoButtonScript : MonoBehaviour
{

    // Start is called before the first frame update
    Vector3 default_scale;
    void Start()
    {
        default_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        transform.localScale = new Vector3(1.15f, 1f, 1.15f);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        transform.localScale = default_scale;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}

using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{

    Vector3 default_scale;

    public RepoItem repoData;
    public bool clickable = false;

    void Start()
    {
        default_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (clickable)
        {
            Debug.Log("Clicked - " + repoData.name);
            string rds = JsonConvert.SerializeObject(repoData);
            PlayerPrefs.SetString("repoData", rds);
            SceneManager.LoadScene("map");
        }
    }

    void OnMouseOver()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    void OnMouseExit()
    {
        transform.localScale = default_scale;
    }
}

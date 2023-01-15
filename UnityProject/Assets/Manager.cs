using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public TMP_Text repoName;
    public GunScript gunScript;
    void Start()
    {
        string rds = PlayerPrefs.GetString("repoData");
        RepoItem repoData = JsonConvert.DeserializeObject<RepoItem>(rds);
        repoName.text = repoData.name;

        for (int i = 0; i < 10; i++)
        {
            gunScript.spawnBullet();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

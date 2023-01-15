using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Links
{
    public class Self
    {
        public string href;
    }
    public class Avatar
    {
        public string href;
    }
}

public class Watcher
{
    public string display_name;
    public string nickname;
    public string account_id;
    public Links links;

}

public class Watchers
{
    public Watcher[] values;
}

public class Manager : MonoBehaviour
{
    public TMP_Text repoName;
    public TMP_Text screenText;
    public GunScript gunScript;
    int seconds = 0;
    int watcherCount = 0;
    RepoItem repoData;

    public GameObject enemyPrefab;

    public int xMax = 20, xMin = -23, zMax = 15, zMin = -29;
    void Start()
    {
        string rds = PlayerPrefs.GetString("repoData");
        repoData = JsonConvert.DeserializeObject<RepoItem>(rds);
        repoName.text = repoData.name;
        StartCoroutine(getWatcherData());
    }

    IEnumerator getWatcherData()
    {
        string getReposForUsername = "https://bitbucket.org/api/2.0/repositories/" + repoData.full_name + "/watchers";
        Watchers watchers = new Watchers();
        using (UnityWebRequest www = UnityWebRequest.Get(getReposForUsername))
        {
            yield return www.SendWebRequest();
            if (www.responseCode == 200)
            {
                watchers = JsonConvert.DeserializeObject<Watchers>(www.downloadHandler.text);
                watcherCount = watchers.values.Length;
                screenText.text = watcherCount + "\n" + seconds;
                for (int i = 0; i < watcherCount; i++)
                {
                    if (watcherCount >= 20) break;

                    gunScript.spawnBullet(watchers.values[i].display_name);

                }
                InvokeRepeating("IncrementTime", 1f, 1f);
            }
        }

    }

    void IncrementTime()
    {
        seconds++;
    }

    public void DecrementWatcherCount()
    {
        if (watcherCount > 0)
            watcherCount--;
    }

    public void IncrementWatcherCount()
    {
        watcherCount++;
    }

    // Update is called once per frame
    void Update()
    {
        screenText.text = watcherCount + "\n" + seconds;
    }
}

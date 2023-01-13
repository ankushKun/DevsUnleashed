using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class getRepoResponse
{
    public class OwnerObject
    {
        public string display_name;
        public string type;
        public string nickname;
        public string account_id;
        public string uuid;
    }

    public class Workspace
    {
        public string type;
        public string slug;
        public string name;
        public string uuid;

    }
    public class RepoItem
    {
        public string full_name;
        public string name;
        public string slug;
        public string description;
        public OwnerObject owner;
        public Workspace workspace;

        public DateTime created_on;
        public DateTime updated_on;
    }

    public RepoItem[] values;
}

public class PlayButton : MonoBehaviour
{
    public AnimationCurve myCurve;
    private ParticleSystem clickParticles;

    private TMP_InputField usernameInput;

    void Start()
    {
        clickParticles = GetComponent<ParticleSystem>();
        usernameInput = GameObject.Find("UsernameInput").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }

    IEnumerator ShowRepos()
    {
        clickParticles.Play();
        string username = usernameInput.text.Trim();
        string getReposForUsername = "https://bitbucket.org/api/2.0/repositories/" + username;
        getRepoResponse res = new getRepoResponse();
        using (UnityWebRequest uwr = UnityWebRequest.Get(getReposForUsername))
        {
            yield return uwr.SendWebRequest();
            if (uwr.responseCode == 200)
            {
                res = JsonConvert.DeserializeObject<getRepoResponse>(uwr.downloadHandler.text);

            }
            else
            {
                print(uwr.error);
            }
        }

    }

    void OnMouseDown()
    {
        print("Play btn clicked");
        StartCoroutine(ShowRepos());
    }
}

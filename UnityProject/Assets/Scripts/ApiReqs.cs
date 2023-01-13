using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    void Start()
    {
        // StartCoroutine(getRequest("http://bitbucket.org/api/2.0/repositories/","bhawna1203"));
    }

    IEnumerator getRequest(string uri, string userID)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri + userID);
        yield return uwr.SendWebRequest();

        switch (uwr.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                print(": Error: " + uwr.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                print(": HTTP Error: " + uwr.error);
                break;
            case UnityWebRequest.Result.Success:
                print(":\nReceived: " + uwr.downloadHandler.text);
                var deserialize = JsonUtility.FromJson<Repo>(uwr.downloadHandler.text);
                break;
        }
    }
}

public class Repo
{
    public string type;
    public string full_name;
    public string name;
    public bool has_issues;
}
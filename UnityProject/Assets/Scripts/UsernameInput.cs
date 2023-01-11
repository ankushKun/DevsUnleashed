using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameInput : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public GameObject disabledPlayBtn;
    public GameObject enabledPlayBtn;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (usernameInput.text.Length >= 2)
        {
            disabledPlayBtn.SetActive(false);
            enabledPlayBtn.SetActive(true);
        }
        else
        {
            disabledPlayBtn.SetActive(true);
            enabledPlayBtn.SetActive(false);
        }
    }
}
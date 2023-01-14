using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameInput : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public GameObject menu;
    public GameObject disabledPlayBtn;
    public GameObject enabledPlayBtn;

    public GameObject levelUI;

    void Start()
    {
        usernameInput = GetComponent<TMP_InputField>();
        menu.SetActive(true);
        disabledPlayBtn.SetActive(true);
        enabledPlayBtn.SetActive(false);
        hideLevelUI();

    }

    void hideLevelUI()
    {
        levelUI.transform.GetChild(0).gameObject.SetActive(false);
        levelUI.transform.GetChild(1).gameObject.SetActive(false);
        levelUI.transform.GetChild(2).gameObject.SetActive(false);
        menu.SetActive(true);
    }

    void showLevelUI()
    {
        levelUI.transform.GetChild(0).gameObject.SetActive(true);
        levelUI.transform.GetChild(1).gameObject.SetActive(true);
        levelUI.transform.GetChild(2).gameObject.SetActive(true);
        menu.SetActive(false);
    }

    // Update is called once per frame
    int prevLen = 0;
    void Update()
    {
        if (usernameInput.text.Length >= 2)
        {
            disabledPlayBtn.SetActive(false);
            enabledPlayBtn.SetActive(true);
            if (prevLen != usernameInput.text.Length)
            {
                hideLevelUI();
            }
            prevLen = usernameInput.text.Length;
        }
        else
        {
            disabledPlayBtn.SetActive(true);
            enabledPlayBtn.SetActive(false);
        }
    }
}

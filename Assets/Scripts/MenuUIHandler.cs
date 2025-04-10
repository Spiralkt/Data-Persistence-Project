using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    
    public TMP_InputField nameInputField;
    public Button saveButton;
    public TMP_Text BestScore;

    public void Start()
    {
        nameInputField.text=PlayerData.Instance.PlayerName;
        BestScore.text = "Best Score : " + PlayerData.Instance.BestPlayer + ":" + PlayerData.Instance.BestScore;

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    public void TextInput()
    {
        PlayerData.Instance.PlayerName = nameInputField.text;
        PlayerData.Instance.SavePlayerName();
    }

    public void SaveData()
    {

    }
}

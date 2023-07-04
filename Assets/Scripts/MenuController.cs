using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    public TMP_Text bestScoreText;
    public TMP_InputField nameInput;


    private void Start()
    {
        bestScoreText.SetText("Best Score: " + PersistanceManager.Instance.highScoreHolder + " : " + PersistanceManager.Instance.highScore);

    }

    public void StartGame()
    {
        PersistanceManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        PersistanceManager.Instance.SaveScoreToFile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

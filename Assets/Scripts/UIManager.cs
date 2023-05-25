using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

//[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public TMP_InputField newName;
    public TMP_Text gameoverText;
    public TMP_Text highscoreText;
    private void Start()
    {
        gameoverText.gameObject.SetActive(SaveLoadManager.Instance.isGameover);
        if (SaveLoadManager.Instance.newHighScore)
        {
            highscoreText.text = "New Highscore";
            newName.gameObject.SetActive(true);
            newName.ActivateInputField();
        }
        else
        {
            highscoreText.text = "Current Highscore is\n" + SaveLoadManager.Instance.highScoreName + " : " + SaveLoadManager.Instance.highScore;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //MasterManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SetNewName()
    {
        SaveLoadManager.Instance.highScoreName = newName.text;
        SaveLoadManager.Instance.Save();
    }
}

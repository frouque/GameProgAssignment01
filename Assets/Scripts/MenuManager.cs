using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text ScoreText;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (ScoreText != null)
        {
            float Score = GameManager.Instance.GetScore();
            ScoreText.text = "Score: " + Score;
        }
    }
    public void OnGameStartClick()
    {
        SceneManager.LoadScene(1);
        if (GameManager.Instance.GetScore() != 0)
        {
            GameManager.Instance.ResetScore();
        }
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}

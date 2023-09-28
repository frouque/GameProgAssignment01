using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // Write down your variables here
    float StartScore;
    public float Score = 0;

    private void Awake()
    {
        StartScore = Score;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void IncrementScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        HUDManager.Instance.UpdateScore(Score);
    }
    public void RestartLevel()
    {
        Score = StartScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HUDManager.Instance.UpdateScore(Score);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartScore = Score;
    }
    public void ResetScore()
    {
        Score = 0;
        StartScore = 0;
        HUDManager.Instance.UpdateScore(Score);
    }
    public float GetScore()
    {
        return Score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text ScoreText;
    public static HUDManager Instance { get; private set; }
    void Start()
    {
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

    public void UpdateScore(float Score)
    {
        ScoreText.text = "Score: " + Score;
    }
}

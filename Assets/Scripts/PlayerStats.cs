using TMPro;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public bool gameOver;

    [SerializeField] private TextMeshProUGUI scoreTextComponent;

    private int score;

    private void Awake()
    {
        if (playerStats == null)
        {
            playerStats = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore(int addScore)
    {
        Debug.Log("updated");
        score += addScore;
        scoreTextComponent.text = "Score : " + score.ToString();
    }

    public void ResetScore()
    {
        Debug.Log("reseted");
    }
}

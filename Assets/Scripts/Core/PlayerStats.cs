using TMPro;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    private TextMeshProUGUI scoreTextComponent;

    private int score = 0;

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


    public void UpdateScore(int addScore)
    {

        score += addScore;
        if (scoreTextComponent == null)
        {

            Debug.Log("score text compo = null");
            scoreTextComponent = gameObject.AddComponent<TextMeshProUGUI>();
        }
        scoreTextComponent.text = "Score : " + score.ToString();
        Debug.Log("updated");

    }

    public void ResetScore()
    {
        Debug.Log("reseted");
        score = 0;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        scoreTextComponent = scoreTextComp;
    }
}

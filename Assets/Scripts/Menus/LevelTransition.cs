using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] CanvasGroup cGroupTransition;
    private float alphaValue = 0;
    private int scoreValue = 0;
    private int highScoreValue = 0;
    private int level;
    private PlayersMovement pm;

    void Start()
    {
        level = 0;
        level = SceneManager.GetActiveScene().buildIndex;
        title.text = "Niveau " + level.ToString(); 
        pm = FindObjectOfType<PlayersMovement>();
    }

    void Update()
    {
        cGroupTransition.alpha = Mathf.Lerp(cGroupTransition.alpha, alphaValue, 2f * Time.deltaTime);
    }

    public void SetAlphaValue(int alpha)
    {
        alphaValue = alpha;
        DisplayStats();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Traps");
        pm.FreezeCrampo();
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    private void DisplayStats()
    {
        Debug.Log(scoreValue);
        scoreValue = PlayerStats.playerStats.GetScore();
        score.text = "Score : " + scoreValue.ToString();
        highScoreValue = PlayerPrefs.GetInt("level" + level.ToString() + "_highscore", 0);
        highScore.text = "Meilleur score : " + highScoreValue.ToString();
        if (scoreValue >= highScoreValue)
        {
            PlayerPrefs.SetInt("level" + level + "_highscore", scoreValue);
            PlayerPrefs.Save();
        }
    }

    public void GoToScene()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        int scene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("maxLevel", scene);
        if (scene < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt("maxLevel", scene);
            PlayerPrefs.Save();
            SceneManager.LoadScene(scene + 1);
        }
        else if (scene >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}

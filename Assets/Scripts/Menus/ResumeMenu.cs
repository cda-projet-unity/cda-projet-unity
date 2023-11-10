using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class ResumeMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup cGroupLevel;
    [SerializeField] CanvasGroup cGroupStats;
    [SerializeField] Sprite btnSrc;
    [SerializeField] Button[] buttons;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI stats;
    private int maxLevel;
    private float alphaValue = 1.0f;
    private int highScore;

    void Start()
    {   
        maxLevel = PlayerPrefs.GetInt("maxLevel", 1);
        for (int i = 0; i < maxLevel; i++)
        {
            PlayerPrefs.DeleteAll();
            buttons[i].image.sprite = btnSrc;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            buttons[i].interactable = true;
            ;
        }
    }

    private void Update()
    {
        cGroupLevel.alpha = Mathf.Lerp(cGroupLevel.alpha, alphaValue,2f * Time.deltaTime);
        cGroupStats.alpha = Mathf.Lerp(cGroupStats.alpha, 1 - alphaValue, 2f * Time.deltaTime);
    }

    public void ChooseLevel(int level)
    {
        Debug.Log(level);
        DisplayStats(level);
    }

    private void DisplayStats(int level)
    {
        alphaValue = 0f;
        highScore = PlayerPrefs.GetInt("level" + level.ToString() + "_highscore", 0);
        title.text = "Niveau " + level.ToString();
        stats.text = "Meilleur score : " + highScore.ToString();
    }
}

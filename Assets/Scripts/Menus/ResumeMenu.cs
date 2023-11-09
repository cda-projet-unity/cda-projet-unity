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
    private int maxLevel;
    private int levelChosen;
    private float alphaValue = 1.0f;

    void Start()
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel", 1);
        string jsonScores = PlayerPrefs.GetString("HighScore", "");
        string[] highScores = jsonScores.Split(",");
        for (int i = 0; i < maxLevel; i++)
        {
            buttons[i].image.sprite = btnSrc;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            buttons[i].interactable = true;
            ;
        }
    }

    private void Update()
    {
        cGroupLevel.alpha = Mathf.Lerp(cGroupLevel.alpha, alphaValue, Time.deltaTime);
        cGroupStats.alpha = Mathf.Lerp(cGroupStats.alpha, 1 - alphaValue, Time.deltaTime);
    }

    public void ChooseLevel(int level)
    {
        alphaValue = 0f;
        Debug.Log(level);
        levelChosen = level;
    }
}

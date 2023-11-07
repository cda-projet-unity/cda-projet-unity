using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class ResumeMenu : MonoBehaviour
{
    [SerializeField] GameObject buttonContainer;
    [SerializeField] private TextMeshProUGUI bannerTitle;
    private int maxLevel;
    private int levelChosen;
    private Button[] levels;

    void Start()
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel", 1);
        //int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);        
    }

    public void ChooseLevel(int level)
    {
        Debug.Log(level);
        levelChosen = level;
    }
}

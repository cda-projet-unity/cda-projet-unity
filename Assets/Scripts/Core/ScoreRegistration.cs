using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreRegistration : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextComponent;
    [SerializeField] private int level = 1;

    private void Start()
    {
        PlayerStats.playerStats.RegisterScoreText(scoreTextComponent);
    }
}

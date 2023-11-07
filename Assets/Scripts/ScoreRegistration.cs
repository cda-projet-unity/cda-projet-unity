using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreRegistration : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextComponent;

    void Awake()
    {
        PlayerStats.playerStats.RegisterScoreText(scoreTextComponent);
    }
}

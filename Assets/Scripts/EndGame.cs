using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame endManager;
    public bool gameOver;

    private TextMeshProUGUI scoreTextComponent;

    private int score;

    private void Awake()
    {
        if (endManager == null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private string infos;
    [SerializeField] private bool showInfos;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;

    private void UpdateTitle(string newTitle)
    {
        title.text = newTitle;
        string data = PlayerPrefs.GetString("level_01");
        string[] values = data.Split(",");
    }

    private void UpdateLevel(int level)
    {
    }
}

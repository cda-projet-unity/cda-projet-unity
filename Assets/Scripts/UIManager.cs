using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Game Over Screen")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        // debug log 
        gameOverScreen.SetActive(false);
    }
    public void GameOver()
    {
        // play game over sound
        gameOverScreen.SetActive(true);  
    }


    // private void Update()
    // {
    //     // if pause screen already active unpause and vice versa
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         PauseGame(!pauseScreen.activeSelf);
    //     }
    // }

    // private bool PauseGame(bool status){
    //     pauseScreen.SetActive(status);
    //     Time.timeScale = status ? 0f : 1f;
    //     return status;
    // }
}

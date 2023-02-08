using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    //UI Elements
    bool isPaused = false;

    [SerializeField] GameObject pausePanel;

    //Custom delegates 
    public delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;
    public delegate void OnLifeUpdate();
    public static OnLifeUpdate onLifeUpdate;


    void Awake()
    {
        onScoreUpdate = ScoreSystem;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        pausePanel.SetActive(isPaused);

        Cursor.visible = isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;//Set a timescale to 0 and pause any behaviour that uses Time to calculate itself
            GameManager.Instance.gameState = GameManager.GameStates.Pause;
        }
        else if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GameManager.Instance.gameState = GameManager.GameStates.Play;
        }
    }

    public void LifeSystemTracker()
    {
        //Task to update the health bar on the screen
    }

    public void ScoreSystem()
    {
        //Task is to update the score on the screen
    }
}

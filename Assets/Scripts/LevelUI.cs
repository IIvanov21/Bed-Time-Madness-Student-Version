using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
    //UI Elements
    bool isPaused = false;
    bool isOptions = false;
    [SerializeField] GameObject pausePanel;

    //Life slider
    [SerializeField] Slider lifeSlider;

    //Score text component
    [SerializeField] TMP_Text score;

    //Custom delegates 
    public delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;
    public delegate void OnLifeUpdate();
    public static OnLifeUpdate onLifeUpdate;


    void Awake()
    {
        onScoreUpdate = ScoreSystem;
        onLifeUpdate = LifeSystemTracker;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOptions)
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

    public void SetOptions(bool value)
    {
        isOptions = value;
    }

    public void LifeSystemTracker()
    {
        //Task to update the health bar on the screen
        if(GameManager.playerHealth>0)lifeSlider.value = GameManager.playerHealth;
    }

    public void ScoreSystem()
    {
        //Task is to update the score on the screen
        score.text = "Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore;
    }
}

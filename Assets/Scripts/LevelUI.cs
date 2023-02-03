using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    //UI Elements
    bool isPaused = false;

    [SerializeField] GameObject pausePanel;


    // Start is called before the first frame update
    void Start()
    {
        
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
}

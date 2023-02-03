using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public enum Scenes
    {
        bootUp,//Reference for the starting credits scene
        title, //Main menu and title
        waveOne,
        waveTwo,
        waveThree,
        waveBoss,//Final boss level
        gameOver,//Load into when the player wins or dies
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.gameState = GameManager.GameStates.Play;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        //Only works when we fully build out our game
        Application.Quit();
    }
}

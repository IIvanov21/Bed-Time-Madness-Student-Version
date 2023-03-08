using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//File library and JSon Utility
using UnityEngine.SceneManagement;//Scene Manager to load a scene

public class Load : MonoBehaviour
{
    string jSonString;
    SaveStructure loadStructure;

    // Start is called before the first frame update
    void Update()
    {
        if (GameManager.isGameInitialised)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.Health = loadStructure.health;
            player.gameObject.transform.position = new Vector3(loadStructure.x, loadStructure.y, loadStructure.z);
            GameManager.playerHealth = loadStructure.health;

            //Update UI elements
            GameManager.Instance.GetComponent<ScoreManager>().SetScore(loadStructure.score);
            LevelUI.onLifeUpdate?.Invoke();
            LevelUI.onScoreUpdate?.Invoke();

            GameManager.isGameInitialised = false;
        }
    }

   public void LoadGame()
   {
        //Step 1: Load the save file information into the jSonString
        jSonString = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");

        //Step 2: Converting the jSonString into a save structure object
        loadStructure = JsonUtility.FromJson<SaveStructure>(jSonString);

        //Step 3: Apply the data to our game
        SceneManager.LoadScene(loadStructure.level);
        GameManager.Instance.gameState = GameManager.GameStates.Play;

   }

}

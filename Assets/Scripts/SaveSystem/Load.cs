using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//File library and JSon Utility
using UnityEngine.SceneManagement;//Scene Manager to load a scene
using UnityEngine.UI;
public class Load : MonoBehaviour
{
    string jSonString;
    SaveStructure loadStructure;


    // Start is called before the first frame update
    void ApplyLoadedSettings()
    {
        GameManager.Instance.gameState = GameManager.GameStates.Play;
        Time.timeScale = 1;
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.Health = loadStructure.health;
        player.gameObject.transform.position = new Vector3(loadStructure.x, loadStructure.y, loadStructure.z);
        GameManager.playerHealth = loadStructure.health;

        //Update UI elements
        GameManager.Instance.GetComponent<ScoreManager>().SetScore(loadStructure.score);
        LevelUI.onLifeUpdate?.Invoke();
        LevelUI.onScoreUpdate?.Invoke();
               
    }

   public void LoadGame()
   {
        //Step 1: Load the save file information into the jSonString
        jSonString = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");

        //Step 2: Converting the jSonString into a save structure object
        loadStructure = JsonUtility.FromJson<SaveStructure>(jSonString);

        //Step 3: Apply the data to our game
        //SceneManager.LoadSceneAsync(loadStructure.level);
        gameObject.SetActive(true);
        StartCoroutine(LoadAsyncScene());
   }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadStructure.level);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }

        ApplyLoadedSettings();
    }


}

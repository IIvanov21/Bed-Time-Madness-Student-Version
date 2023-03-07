using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private string jSonString;
    private SaveStructure saveStructure;

    public void SaveGame()
    {
        //Step 1: Populate the structure with all the data we need to save.
        saveStructure = new SaveStructure();
        saveStructure.health = GameManager.playerHealth;
        saveStructure.score = GameManager.Instance.GetComponent<ScoreManager>().PlayerScore;
        saveStructure.level = SceneManager.GetActiveScene().buildIndex;

        saveStructure.x=GameManager.playerPosition.x;
        saveStructure.y=GameManager.playerPosition.y;
        saveStructure.z=GameManager.playerPosition.z;

        //Step 2: Turn our save structure object into a string
        jSonString=JsonUtility.ToJson(saveStructure);

        //Step 3: Create the save file by writing to it.
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jSonString);
    }
}

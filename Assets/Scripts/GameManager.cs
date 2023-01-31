using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }//Access to the GameManager publicly
        private set { instance = value; }//Only allow modification of the GameManager object privately
    }

    private void Start()
    {
        CheckGameManager();
    }

    void CheckGameManager()
    {
        //1. To check if there is already an existing GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //2. If a gameobject for the GameManager exists, we destroy the new game object that is trying to create itself. 
        {
            Destroy(this.gameObject);
        }
    }
}

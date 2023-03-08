using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureSaveButtons : MonoBehaviour
{
    Button loadButton;
    // Start is called before the first frame update
    void Start()
    {
        loadButton = GetComponent<Button>();
        Debug.Log(loadButton.name);
        loadButton.onClick.AddListener(GameManager.Instance.GetComponent<Load>().LoadGame);
    }

  
}

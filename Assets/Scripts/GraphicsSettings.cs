using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Access to generic UI elements
using TMPro;//Access to text properties 

public class GraphicsSettings : MonoBehaviour
{
    //Toggle switches for Fullscreen and Vsync
    [SerializeField] Toggle fullScreenTog, vSyncTog;
    [SerializeField] List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    [SerializeField] TMP_Text resolutionText;

    //Quality Settings controls
    [SerializeField] Dictionary<int, string> qualitySettings = new Dictionary<int, string>();
    private int selectedQuality;
    [SerializeField] TMP_Text qualityText;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        

        //Resolutions settings capture
        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateRes();
            }
        }



        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal=Screen.width;
            newRes.vertical=Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;
            UpdateRes();
        }

        //Quality Settings checks
        if (QualitySettings.vSyncCount == 0)
        {
            vSyncTog.isOn = false;
        }
        else
        {
            vSyncTog.isOn = true;
        }

        qualitySettings.Add(0, "Very Low");
        qualitySettings.Add(1, "Low");
        qualitySettings.Add(2, "Medium");
        qualitySettings.Add(3, "High");
        qualitySettings.Add(4, "Very High");
        qualitySettings.Add(5, "Ultra");

        UpdateQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGraphics()
    {
        //Resolutions settings
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical,fullScreenTog.isOn);
        
        //Quality settings
        if (vSyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else 
        {
            QualitySettings.vSyncCount = 0;
        }

        QualitySettings.SetQualityLevel(selectedQuality);
    }

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0) selectedResolution = resolutions.Count - 1;
        UpdateRes();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1) selectedResolution = 0;
        UpdateRes();
    }

    void UpdateRes()
    {
        resolutionText.text = resolutions[selectedResolution].horizontal + "X" + resolutions[selectedResolution].vertical;
    }

    void UpdateQualityLevel()
    {
        qualityText.text = qualitySettings[selectedQuality];
    }

    public void QLeft()
    {
        selectedQuality--;
        if(selectedQuality< 0) selectedQuality = qualitySettings.Count - 1;
        UpdateQualityLevel();
    }

    public void QRight()
    {
        selectedQuality++;
        if(selectedQuality>qualitySettings.Count-1) selectedQuality = 0;
        UpdateQualityLevel();
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal;//Screen width
    public int vertical;//Screen height
}
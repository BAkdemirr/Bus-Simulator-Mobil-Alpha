using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameras : MonoBehaviour
{

    public GameObject mainMenuCamera;
    public GameObject busSelectionCamera;
    public GameObject mainMenuUI;
    public GameObject busMenuUI;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MainMenuCamera()
    {
        mainMenuCamera.SetActive(true);
        mainMenuUI.SetActive(true);
        busSelectionCamera.SetActive(false);
        busMenuUI.SetActive(false);
    }

    public void BusSelectionCamera()
    {
        busSelectionCamera.SetActive(true);
        busMenuUI.SetActive(true);
        mainMenuCamera.SetActive(false);
        mainMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

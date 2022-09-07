using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public int currentBusIndex;
    public GameObject[] busModels;

    public BusBlueprint[] busses;
    public Button buyButton;

    public PlayerManager pm;

    void Start()
    {
        foreach (BusBlueprint bus in busses) 
        {
            // if else in tamamı ilk otobüsün isunlocked ı true olması için
            if (bus.price == 0)
                bus.isUnlocked = true;
            else
            {
                if (PlayerPrefs.GetInt(bus.name, 0) == 0) 
                {
                    bus.isUnlocked = false;
                }
                else
                {
                    bus.isUnlocked = true;
                }
            }
        }



        currentBusIndex = PlayerPrefs.GetInt("SelectedBus", 0);

        foreach (GameObject bus in busModels) 
            bus.SetActive(false);

        busModels[currentBusIndex].SetActive(true);
    }

    private void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        busModels[currentBusIndex].SetActive(false);
        currentBusIndex++;
        if (currentBusIndex == busModels.Length)
            currentBusIndex = 0;

        busModels[currentBusIndex].SetActive(true);

        BusBlueprint b = busses[currentBusIndex];
        if (!b.isUnlocked) 
            return;
        PlayerPrefs.SetInt("SelectedBus", currentBusIndex);
    }

    public void ChangePrevious()
    {
        /* 
         * busModels[currentBusIndex].SetActive(false);
         * currentBusIndex--;
         * if (currentBusIndex == -1)
         *      currentbusIndex=0;
         * busModels[currentBusIndex].SetActive(true);
         * PlayerPrefs.SetInt("SelectedBus", currentBusIndex);
         */
        busModels[currentBusIndex].SetActive(false);
        currentBusIndex--;
        if (currentBusIndex == -1)
            currentBusIndex = busModels.Length - 1;

        busModels[currentBusIndex].SetActive(true);

        BusBlueprint b = busses[currentBusIndex];
        if (!b.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedBus", currentBusIndex);
    }

    public void UnlockBus()
    {
        BusBlueprint b = busses[currentBusIndex];

        PlayerPrefs.SetInt(b.name, 1);
        PlayerPrefs.SetInt("SelectedBus", currentBusIndex);
        b.isUnlocked = true;
        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash", 0) - b.price);

        pm.cashText.text = " " + PlayerPrefs.GetInt("Cash");
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    void UpdateUI()
    {
        BusBlueprint b = busses[currentBusIndex];
        if (b.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "Buy: " + b.price;
            if (b.price < PlayerPrefs.GetInt("Cash", 0))  
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }

}

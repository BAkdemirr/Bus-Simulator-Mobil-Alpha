using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedBus : MonoBehaviour
{
    public int currentBusIndex;
    public GameObject[] buses;


    void Start()
    {
        currentBusIndex = PlayerPrefs.GetInt("SelectedBus", 0);

        foreach (GameObject bus in buses)
            bus.SetActive(false);

        buses[currentBusIndex].SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int currentCash = 0;
    public Text cashText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Cash")) 
        {
            currentCash = PlayerPrefs.GetInt("Cash");
        }
        else
        {
            currentCash = 0;
        }

        cashText.text = " " + currentCash;

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "cash") 
        {
            Destroy(col.gameObject);
            currentCash += 100;
            PlayerPrefs.SetInt("Cash", currentCash);
            cashText.text = " " + currentCash;
        }
    }



}

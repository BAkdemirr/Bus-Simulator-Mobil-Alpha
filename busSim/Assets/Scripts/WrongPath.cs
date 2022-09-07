using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongPath : MonoBehaviour
{
    public GameObject wrongwayMessage;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player") 
        {
            wrongwayMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            wrongwayMessage.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}

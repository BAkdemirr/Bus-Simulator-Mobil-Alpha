using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OnTriggerPlay : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject RCCCam;
    public GameObject cameraAnim;
    public GameObject mainBus;
    public GameObject animationBus;
    public GameObject MainUI;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player") 
        {
            RCCCam.SetActive(false);
            cameraAnim.SetActive(true);
            mainBus.SetActive(false);
            animationBus.SetActive(true);
            MainUI.SetActive(false);
            timeline.Play();

            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ResumeGame());
            



        }
    }

    IEnumerator ResumeGame()
    {
        yield return new WaitForSeconds(7);
        
        timeline.Stop();
        RCCCam.SetActive(true);
        cameraAnim.SetActive(false);
        mainBus.SetActive(true);
        animationBus.SetActive(false);
        MainUI.SetActive(true);
        
    }


}

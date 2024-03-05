using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageState : MonoBehaviour
{
    private bool respondable;
    public GameObject screen;
    public GameObject messagePlus;
    public GameObject response1;
    public GameObject response2;
    public GameObject option;

    private GameObject response;

    private bool strt;
    private bool respondswitch;

    // Start is called before the first frame update
    void Start()
    {
        strt = false;
        respondable = true;
        respondswitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (screen.activeInHierarchy)
        {
            if (!strt)
            {
                strt = true;
                messagePlus.SetActive(true);
            }
        }
        /* if (response.tag == "Res" && screen.activeInHierarchy && !respondable && !response1.activeInHierarchy && !messagePlus.activeInHierarchy && !response2.activeInHierarchy && !option.activeInHierarchy)
        {
            respondswitch = true;
        } */
        if (!respondswitch)
        {
            if ((!respondable && screen.activeInHierarchy)) // || (!respondable && screen.tag == "res1" && response1.tag == "res1")
            {
                messagePlus.SetActive(false);
                response.SetActive(true);
            }
            else if (!option.activeInHierarchy && screen.activeInHierarchy)
            {
                messagePlus.SetActive(true);
            }
            if (option.activeInHierarchy && screen.activeInHierarchy)
            {
                messagePlus.SetActive(false);
            }
            if (screen.activeInHierarchy && response1.activeInHierarchy)
            {
                // Debug.Log("screen: " + screen.tag + "response: " + response1.tag);
                response = response1;
                respondable = false;
            }
            if (screen.activeInHierarchy && response2.activeInHierarchy)
            {
                response = response2;
                respondable = false;
            }
        }
    }
}

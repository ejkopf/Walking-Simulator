using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageState : MonoBehaviour
{
    private bool respondable;
    public GameObject screen;
    public GameObject messagePlus;
    public GameObject response;
    public GameObject option;

    // Start is called before the first frame update
    void Start()
    {
        respondable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!respondable && screen.activeInHierarchy)
        {
            messagePlus.SetActive(false);
            response.SetActive(true);
        } else if (!option.activeInHierarchy)
        {
            messagePlus.SetActive(true);
        }
        if (screen.activeInHierarchy && response.activeInHierarchy)
        {
            respondable = false;
        }
    }
}

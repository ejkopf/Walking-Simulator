using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using cse481.logging;

public class PhoneButton : MonoBehaviour // , IPointerClickHandler
{
    public GameObject button1;
    public GameObject button2;
    public GameObject back;
    public GameObject phoneback;
    private CapstoneLogger logger;
    // public GameObject

    // Start is called before the first frame update
    void Start()
    {
        back.SetActive(false);
        phoneback.SetActive(false);
        CapstoneLogger logger = new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        this.logger = logger;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        // logger.LogActionWithNoLevel(5, "phone button");
        Debug.Log("Click!" + transform.gameObject.tag);
        Debug.Log(back.tag);
        button1.SetActive(false);
        button2.SetActive(false);
        back.SetActive(true);
        phoneback.SetActive(true);
    }
}

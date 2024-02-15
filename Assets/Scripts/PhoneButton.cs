using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneButton : MonoBehaviour // , IPointerClickHandler
{
    public GameObject button1;
    public GameObject button2;
    public GameObject back;
    public GameObject phoneback;
    // public GameObject

    // Start is called before the first frame update
    void Start()
    {
        back.SetActive(false);
        phoneback.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("Click!" + transform.gameObject.tag);
        Debug.Log(back.tag);
        button1.SetActive(false);
        button2.SetActive(false);
        back.SetActive(true);
        phoneback.SetActive(true);
    }
}

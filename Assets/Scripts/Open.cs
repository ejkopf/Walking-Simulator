using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Open : MonoBehaviour // , IPointerClickHandler
{
    public GameObject currentScreen;
    public GameObject current2;
    public GameObject screenToOpen;
    public GameObject screenToOpen2;

    // Start is called before the first frame update
    void Start()
    {
        if (screenToOpen.tag != "GameController")
        {
            screenToOpen.SetActive(false);
            screenToOpen2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("Click!" + transform.gameObject.tag);
        Debug.Log(screenToOpen.tag);
        currentScreen.SetActive(false);
        current2.SetActive(false);
        screenToOpen.SetActive(true);
        screenToOpen2.SetActive(true);
    }
}

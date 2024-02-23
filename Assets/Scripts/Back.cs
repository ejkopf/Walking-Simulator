using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cse481.logging;

public class Back : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject current2;
    public GameObject screenToOpen;
    public GameObject screenToOpen2;
    private CapstoneLogger logger;

    // Start is called before the first frame update
    void Start()
    {
        currentScreen.SetActive(false);
        current2.SetActive(false);
        CapstoneLogger logger = new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        this.logger = logger;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        // logger.LogActionWithNoLevel(3, "back");
        // logger.LogLevelEnd("Phone is put away");
        Debug.Log("Click!" + transform.gameObject.tag);
        // Debug.Log(screenToOpen.tag);
        currentScreen.SetActive(false);
        current2.SetActive(false);
        screenToOpen.SetActive(true);
        screenToOpen2.SetActive(true);
    }
}

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
    }

    void Awake()
    {
        logger = Logger.Instance.logger;
        string userID = logger.GetSavedUserId();
        if (userID is null || userID is "")
        {
            userID = logger.GenerateUuid();
            logger.SetSavedUserId(userID);
        }
        logger.StartNewSession(userID);
    }

    // Update is called once per frame
    void Update()
    {    
    }

    void OnMouseDown()
    {
        logger.LogActionWithNoLevel(10, "back" + "." + logger.GetSavedUserId());

        currentScreen.SetActive(false);
        current2.SetActive(false);
        screenToOpen.SetActive(true);
        screenToOpen2.SetActive(true);
    }
}

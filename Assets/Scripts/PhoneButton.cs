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

    // Start is called before the first frame update
    void Start()
    {
        logger = Logger.Instance.logger;
        string userID = logger.GetSavedUserId();
        if (userID is null || userID is "")
        {
            userID = logger.GenerateUuid();
            logger.SetSavedUserId(userID);
        }
        logger.StartNewSession(userID);

        back.SetActive(false);
        phoneback.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        logger.LogActionWithNoLevel(5, "phone" + "." + logger.GetSavedUserId());

        button1.SetActive(false);
        button2.SetActive(false);
        back.SetActive(true);
        phoneback.SetActive(true);
    }
}

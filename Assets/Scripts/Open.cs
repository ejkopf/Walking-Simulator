using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cse481.logging;

public class Open : MonoBehaviour
{
    public GameObject current;
    public GameObject messages;
    private CapstoneLogger logger;

    // Start is called before the first frame update
    void Start()
    {
        if (current.transform.tag != "Photos")
        {
            current.SetActive(false);
        }

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
        current.SetActive(false);
        messages.SetActive(true);
    }
}

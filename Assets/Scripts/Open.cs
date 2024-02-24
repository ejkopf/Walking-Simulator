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
        CapstoneLogger logger = new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        this.logger = logger;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        logger.LogActionWithNoLevel(4, transform.gameObject.tag);
        logger.LogLevelStart(0, "Phone");
        Debug.Log("Click!" + transform.gameObject.tag);
        // Debug.Log(screenToOpen.tag);
        current.SetActive(false);
        messages.SetActive(true);
    }
}

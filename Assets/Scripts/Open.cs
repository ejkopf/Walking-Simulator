using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cse481.logging;

public class Open : MonoBehaviour
{
    public GameObject current;
    public GameObject messages;

    // Start is called before the first frame update
    void Start()
    {
        if (current.transform.tag != "Photos")
        {
            current.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Logger.Instance.logger.LogActionWithNoLevel(4, transform.gameObject.tag);
        Logger.Instance.logger.LogLevelStart(0, "Phone");
        Debug.Log("Click!" + transform.gameObject.tag);
        // Debug.Log(screenToOpen.tag);
        current.SetActive(false);
        messages.SetActive(true);
    }
}

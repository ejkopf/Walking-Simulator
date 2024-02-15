using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMessages : MonoBehaviour
{
    public GameObject current;
    public GameObject messages;

    // Start is called before the first frame update
    void Start()
    {
        current.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("Click!" + transform.gameObject.tag);
        // Debug.Log(screenToOpen.tag);
        current.SetActive(false);
        messages.SetActive(true);
    }
}

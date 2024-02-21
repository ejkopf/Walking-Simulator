using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{
    public GameObject current;
    public GameObject options;
    public GameObject opt1;
    public GameObject opt2;
    private bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        current.SetActive(false);
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            current.SetActive(false);
            options.SetActive(true);
            opt1.SetActive(true);
            opt2.SetActive(true);
            
        }
        if (opt1.activeInHierarchy)
        {
            clicked = false;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Click! message+" + transform.gameObject.tag);
        // Debug.Log(screenToOpen.tag);
        current.SetActive(false);
        clicked = true;
        options.SetActive(true);
        opt1.SetActive(true);
        opt2.SetActive(true);
    }
}

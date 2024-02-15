using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockMe : MonoBehaviour
{
    public GameObject screen;
    public GameObject messages;
    // Start is called before the first frame update
    void Start()
    {
        screen.SetActive(false);
        foreach (Transform child in messages.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(screen.activeInHierarchy + (Time.time).ToString());
        if (screen.activeInHierarchy)
        {
            if (Time.time > 100f) // revise
            {
                messages.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (Time.time > 105f)
            {
                messages.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (Time.time > 110f)
            {
                messages.transform.GetChild(2).gameObject.SetActive(true);
            }
            if (Time.time > 115f)
            {
                messages.transform.GetChild(3).gameObject.SetActive(true);
            }
            /* if (Time.time > 120f) // take last 2 out for spacing reasons
            {
                messages.transform.GetChild(4).gameObject.SetActive(true);
            }
            if (Time.time > 125f)
            {
                messages.transform.GetChild(5).gameObject.SetActive(true);
            } */
        }
        if (!screen.activeInHierarchy) // add if statements as above,, send notif if not active.. yeah
        {
            foreach (Transform child in messages.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}

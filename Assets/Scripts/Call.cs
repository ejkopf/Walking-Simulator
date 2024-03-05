using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Call : MonoBehaviour
{
    public GameObject callContainer;
    private GameObject background;
    private GameObject page1;

    private bool callStarted;
    private float timeStarted;

    // Start is called before the first frame update
    void Start()
    {
        background = callContainer.transform.GetChild(0).gameObject;
        background.SetActive(true);
        page1 = callContainer.transform.GetChild(1).gameObject;
        page1.SetActive(true); // page 1
        foreach (Transform child in callContainer.transform)
        {
            if (child.gameObject != background && child.gameObject != page1)
            {
                child.gameObject.SetActive(false);
            }
        }
        callContainer.SetActive(false);
        callStarted = false;
        timeStarted = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (callContainer.activeInHierarchy)
        {
            if (!callStarted)
            {
                timeStarted = Time.time;
                callStarted = true;
            }
            bool newpage = false;
            foreach (Transform page in callContainer.transform)
            {
                if (page.gameObject != background && newpage)
                {
                    timeStarted = Time.time;
                    page.gameObject.SetActive(true);
                    newpage = false;
                }
                if (page.gameObject != background && page.gameObject.activeInHierarchy) // ensure page is a page
                {
                    for (int i = 0; i < page.childCount; i++) // fade in all children
                    {
                        // Debug.Log(Time.time + " - " + timeStarted + " > " + 3f * i);
                        if (Time.time - timeStarted > 3f * i)
                        {
                            Text text = page.GetChild(i).GetChild(0).GetComponentInChildren(typeof(Text)) as Text;
                            // Debug.Log(page.GetChild(i).GetChild(0).GetComponentInChildren<Text>().Text);
                            Debug.Log(text.text);
                            ColorChange(page.GetChild(i).GetChild(0).GetComponentInChildren<Text>(), 0.05f);
                        } else
                        {
                            ColorChange(page.GetChild(i).GetChild(0).GetComponentInChildren<Text>(), -page.GetChild(i).GetChild(0).GetComponentInChildren<Text>().color.a);
                        }
                    }
                    if (Time.time - timeStarted > 4f * (page.childCount + 1f))
                    {
                        page.gameObject.SetActive(false);
                        if (page != callContainer.transform.GetChild(callContainer.transform.childCount - 1))
                        {
                            newpage = true;
                        } else
                        {
                            callContainer.SetActive(false);
                        }
                    }
                }
            }
            
        }
    }

    void ColorChange(Text given, float amount)
    {
        Color col = given.color;
        col.a += amount;
        given.color = col;
    }
}

using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Roomie : MonoBehaviour
{
    public Text notificationtext;
    public GameObject tutorialtext;

    public GameObject roomieStart;
    public GameObject pg1; // notifs
    public GameObject pg2; // notifs (1)
    public GameObject response1;
    public GameObject response2;
    public GameObject options;
    public GameObject backButton;

    private bool donewith1stinstruction;
    private bool donewith2ndinstruction;
    private bool donewith3rdinstruction;
    private bool donewith4thinstruction;
    private bool done5;

    private bool tutorialcomplete;
    private float timetutorialend;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        pg2.transform.GetChild(0).gameObject.SetActive(false);
        pg2.transform.GetChild(1).gameObject.SetActive(false);
        pg2.transform.GetChild(2).gameObject.SetActive(false);
        pg2.transform.GetChild(3).gameObject.SetActive(false);
        pg2.transform.GetChild(4).gameObject.SetActive(false);
        pg2.transform.GetChild(5).gameObject.SetActive(false);

        donewith1stinstruction = false;
        donewith2ndinstruction = false;
        donewith3rdinstruction = false;
        donewith4thinstruction = false;
        done5 = false;

        timetutorialend = 0f;
        time = 0f;

        roomieStart.SetActive(false);
        foreach (Transform child in pg1.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in pg2.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialtext.activeInHierarchy)
        {
            tutorialcomplete = true;
        }
        if (tutorialcomplete)
        {
            if (!donewith1stinstruction)
            {
                donewith1stinstruction = true;
                timetutorialend = Time.time;
            }

            // notif
            if (Time.time - timetutorialend > 30f && donewith1stinstruction && !backButton.activeInHierarchy && !donewith3rdinstruction)
            {
                if (!donewith2ndinstruction)
                {
                    donewith2ndinstruction = true;
                }
                ColorChange(notificationtext, 0.1f);
            }

            if (roomieStart.activeInHierarchy && !donewith3rdinstruction && donewith2ndinstruction)
            {
                if (!donewith3rdinstruction)
                {
                    donewith3rdinstruction = true;
                    time = Time.time;
                }
                pg1.transform.GetChild(0).gameObject.SetActive(true);
                if (Time.time - time > 1f)
                {
                    pg1.transform.GetChild(1).gameObject.SetActive(true);
                }
                if (Time.time - time > 1.5f)
                {
                    pg1.transform.GetChild(2).gameObject.SetActive(true);
                }
                if (Time.time - time > 2f)
                {
                    pg1.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (Time.time - time > 8f)
                {
                    pg1.SetActive(false);
                    pg2.transform.GetChild(0).gameObject.SetActive(true);
                    pg2.transform.GetChild(1).gameObject.SetActive(true);
                    pg2.transform.GetChild(2).gameObject.SetActive(true);
                    pg2.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (Time.time - time > 8.5f)
                {
                    pg2.transform.GetChild(4).gameObject.SetActive(true);
                }
                if (Time.time - time > 8.5f)
                {
                    pg2.transform.GetChild(5).gameObject.SetActive(true);
                }
                if (Time.time - time > 9f)
                {
                    pg2.transform.GetChild(6).gameObject.SetActive(true);
                }
            }
            else if (roomieStart.activeInHierarchy && done5)
            {
                pg2.transform.GetChild(0).gameObject.SetActive(true);
                pg2.transform.GetChild(1).gameObject.SetActive(true);
                pg2.transform.GetChild(2).gameObject.SetActive(true);
                pg2.transform.GetChild(3).gameObject.SetActive(true);
                pg2.transform.GetChild(4).gameObject.SetActive(true);
                pg2.transform.GetChild(5).gameObject.SetActive(true);
            }

            if (options.activeInHierarchy && donewith3rdinstruction)
            {
                if (!donewith4thinstruction)
                {
                    donewith4thinstruction = true;
                }
            }

            if ((response1.activeInHierarchy && donewith4thinstruction) || (response2.activeInHierarchy && donewith4thinstruction))
            {
                if (!done5)
                {
                    done5 = true;
                }
            }

            if (!roomieStart.activeInHierarchy)
            {
                pg2.transform.GetChild(0).gameObject.SetActive(false);
                pg2.transform.GetChild(1).gameObject.SetActive(false);
                pg2.transform.GetChild(2).gameObject.SetActive(false);
                pg2.transform.GetChild(3).gameObject.SetActive(false);
                pg2.transform.GetChild(4).gameObject.SetActive(false);
                pg2.transform.GetChild(5).gameObject.SetActive(false);
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

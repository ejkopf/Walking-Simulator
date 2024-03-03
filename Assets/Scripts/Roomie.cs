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
    public GameObject phoneBack;
    public GameObject responseContainer;
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;
    public GameObject responsebacklog;
    public GameObject notifs;

    private bool donewith1stinstruction;
    private bool donewith2ndinstruction;
    private bool done2point5;
    private bool donewith3rdinstruction;
    private bool donewith4thinstruction;
    private bool done5;
    private bool done6;
    private bool done7;
    private bool[] bools;

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

        notifs.transform.GetChild(0).gameObject.SetActive(false);
        notifs.transform.GetChild(1).gameObject.SetActive(false);
        notifs.transform.GetChild(2).gameObject.SetActive(false);

        responseContainer.SetActive(false);
        responsebacklog.SetActive(false);

        donewith1stinstruction = false;
        donewith2ndinstruction = false;
        done2point5 = false;
        donewith3rdinstruction = false;
        donewith4thinstruction = false;
        done5 = false;
        done6 = false;
        done7 = false;
        bools = new bool[100];

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
            // Debug.Log("startRoomie");
            if (!donewith1stinstruction)
            {
                
                donewith1stinstruction = true;
                timetutorialend = Time.time;
            }

            // notif CHANGE BACK TO 30f
            if (Time.time - timetutorialend > 0f && donewith1stinstruction && !backButton.activeInHierarchy && !done2point5)
            {
                if (!donewith2ndinstruction)
                {
                    donewith2ndinstruction = true;
                    Vector3 slide1pos = slide1.transform.position;
                    // Debug.Log(slide1pos.y + " > " + slide2.transform.position.y + " && " + slide2.transform.position.z + " < " + slide3.transform.position.z);
                    if (slide1pos.y > slide2.transform.position.y && slide2.transform.position.y > slide3.transform.position.y)
                    {
                        // Debug.Log("yep");
                        slide1.transform.position = slide2.transform.position;
                        slide2.transform.position = slide1pos;
                    } else // slide3 > slide 1 > slide 2
                    {
                        // Debug.Log("nope");
                        slide1.transform.position = slide2.transform.position;
                        slide2.transform.position = slide3.transform.position;
                        slide3.transform.position = slide1pos;
                    }
                }
                ColorChange(notificationtext, 0.1f);
            }

            if (phoneBack.activeInHierarchy && donewith2ndinstruction)
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done2point5 = true;
            }

            if (roomieStart.activeInHierarchy && donewith2ndinstruction)
            {
                if (!donewith3rdinstruction)
                {
                    donewith3rdinstruction = true;
                    time = Time.time;
                }
                pg1.SetActive(false);
                roomieStart.transform.GetChild(1).gameObject.SetActive(false);
                // Debug.Log("here");
                pg2.transform.GetChild(0).gameObject.SetActive(true);
                // Debug.Log(Time.time + " - " + time);
                if (Time.time - time > 2f)
                {
                    pg2.transform.GetChild(1).gameObject.SetActive(true);
                }
                if (Time.time - time > 3f)
                {
                    pg2.transform.GetChild(2).gameObject.SetActive(true);
                }
                if (Time.time - time > 4f)
                {
                    pg2.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (Time.time - time > 4f)
                {
                    pg1.SetActive(false);
                    roomieStart.transform.GetChild(1).gameObject.SetActive(false);
                    pg2.transform.GetChild(0).gameObject.SetActive(true);
                    pg2.transform.GetChild(1).gameObject.SetActive(true);
                    pg2.transform.GetChild(2).gameObject.SetActive(true);
                    pg2.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (Time.time - time > 6f)
                {
                    pg2.transform.GetChild(4).gameObject.SetActive(true);
                    if (!bools[3])
                    {
                        Vector3 slide1pos = slide1.transform.position;
                        if (slide1pos.y > slide2.transform.position.y && slide2.transform.position.y > slide3.transform.position.y)
                        {
                            // Debug.Log("yep");
                            slide1.transform.position = slide2.transform.position;
                            slide2.transform.position = slide1pos;
                        }
                        else // slide3 > slide 1 > slide 2
                        {
                            // Debug.Log("nope");
                            slide1.transform.position = slide2.transform.position;
                            slide2.transform.position = slide3.transform.position;
                            slide3.transform.position = slide1pos;
                        }
                        bools[3] = true;
                    }
                }
                if (Time.time - time > 8f)
                {
                    pg2.transform.GetChild(5).gameObject.SetActive(true);
                }
                if (Time.time - time > 9f)
                {
                    responseContainer.SetActive(true);
                    GameObject rss = responseContainer.transform.GetChild(0).gameObject;
                    rss.SetActive(true);
                    if (!done5)
                    {

                        done5 = true;
                        rss.transform.GetChild(0).gameObject.SetActive(false);
                        rss.transform.GetChild(1).gameObject.SetActive(false);
                    }
                    // pg2.transform.GetChild(6).gameObject.SetActive(true);
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
                // Debug.Log("done4");
                if (!donewith4thinstruction)
                {
                    donewith4thinstruction = true;
                }
            }

            if ((response1.activeInHierarchy && donewith4thinstruction) || (response2.activeInHierarchy && donewith4thinstruction))
            {
                if (!done5)
                {
                    // Debug.Log("done5");
                    done5 = true;
                    timetutorialend = Time.time;
                }
            }

            if (!roomieStart.activeInHierarchy)
            {
                pg1.transform.GetChild(0).gameObject.SetActive(false);
                pg1.transform.GetChild(1).gameObject.SetActive(false);
                pg1.transform.GetChild(2).gameObject.SetActive(false);
                pg1.transform.GetChild(3).gameObject.SetActive(false);
                pg2.transform.GetChild(0).gameObject.SetActive(false);
                pg2.transform.GetChild(1).gameObject.SetActive(false);
                pg2.transform.GetChild(2).gameObject.SetActive(false);
                pg2.transform.GetChild(3).gameObject.SetActive(false);
                pg2.transform.GetChild(4).gameObject.SetActive(false);
                pg2.transform.GetChild(5).gameObject.SetActive(false);
            }
        }

        // pt 2
        if (Time.time - timetutorialend > 0f && done5)
        {
            // Debug.Log("start p2");
            // Debug.Log(done7 + " , " + !backButton.activeInHierarchy);
            if (!backButton.activeInHierarchy && !done7)
            {
                // Debug.Log("done6");
                if (!done6)
                {
                    done6 = true;
                }
                ColorChange(notificationtext, 0.1f);
            }

            if (phoneBack.activeInHierarchy && done6)
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done7 = true;
            }

            if (roomieStart.activeInHierarchy && done7)
            {
                // Debug.Log("roomiestrt");
                if (!bools[0])
                {
                    bools[0] = true;
                    time = Time.time;
                }

                pg2.transform.GetChild(0).gameObject.SetActive(false);
                pg2.transform.GetChild(1).gameObject.SetActive(false);
                pg2.transform.GetChild(2).gameObject.SetActive(false);
                pg2.transform.GetChild(3).gameObject.SetActive(false);
                pg2.transform.GetChild(4).gameObject.SetActive(false);
                pg2.transform.GetChild(5).gameObject.SetActive(false);

                responsebacklog.SetActive(true);
                if (response1.activeInHierarchy)
                {
                    response1.SetActive(false);
                    responsebacklog.transform.GetChild(0).gameObject.SetActive(true);
                    responsebacklog.transform.GetChild(1).gameObject.SetActive(false);
                    responseContainer.SetActive(false);
                }
                if (response2.activeInHierarchy)
                {
                    response2.SetActive(false);
                    responsebacklog.transform.GetChild(0).gameObject.SetActive(false);
                    responsebacklog.transform.GetChild(1).gameObject.SetActive(true);
                    responseContainer.SetActive(false);
                }

                notifs.SetActive(true);
                notifs.transform.GetChild(0).gameObject.SetActive(true);
                if (Time.time - time > 2f)
                {
                    notifs.transform.GetChild(1).gameObject.SetActive(true);
                }
                if (Time.time - time > 5.5f)
                {
                    notifs.transform.GetChild(2).gameObject.SetActive(true);
                    bools[1] = true;
                }

                if (bools[1]) {
                    response1.SetActive(false);
                    response2.SetActive(false);
                    responseContainer.SetActive(false);
                }
            }

            if (!roomieStart.activeInHierarchy)
            {
                pg1.transform.GetChild(0).gameObject.SetActive(false);
                pg1.transform.GetChild(1).gameObject.SetActive(false);
                pg1.transform.GetChild(2).gameObject.SetActive(false);
                pg1.transform.GetChild(3).gameObject.SetActive(false);
                pg2.transform.GetChild(0).gameObject.SetActive(false);
                pg2.transform.GetChild(1).gameObject.SetActive(false);
                pg2.transform.GetChild(2).gameObject.SetActive(false);
                pg2.transform.GetChild(3).gameObject.SetActive(false);
                pg2.transform.GetChild(4).gameObject.SetActive(false);
                pg2.transform.GetChild(5).gameObject.SetActive(false);
                responsebacklog.SetActive(false);
                notifs.transform.GetChild(0).gameObject.SetActive(false);
                notifs.transform.GetChild(1).gameObject.SetActive(false);
                notifs.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        void ColorChange(Text given, float amount)
        {
            Color col = given.color;
            col.a += amount;
            given.color = col;
        }
    }
}

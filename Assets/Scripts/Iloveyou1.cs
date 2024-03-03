using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Iloveyou1 : MonoBehaviour
{
    public Text notificationtext;
    public Text ily;
    public GameObject tutorialtext;

    public GameObject ilystart;

    // notifs
    public GameObject notif1;
    public GameObject notif2;
    public GameObject notif3;
    public GameObject notif4;
    public GameObject notif5;
    public GameObject notif6;

    public GameObject response1;
    public GameObject response2;
    public GameObject response1container;
    public GameObject response2container;
    public GameObject response3container;
    public GameObject response4container;
    public GameObject response3;
    public GameObject response4;

    public GameObject option1;
    public GameObject option2;

    public GameObject messageplus2;
    public GameObject messageplus3;
    public GameObject messageplus4;

    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;

    public GameObject backButton;
    public GameObject phoneBack;

    private bool[] done;
    private bool tutorialcomplete;
    private float curtime;
    private float done1time;

    private Vector3 topSlidePos;
    private Vector3 slidePos2;
    private Vector3 slidePos3;
    private Vector3 slidePos4;

    // Start is called before the first frame update
    void Start()
    {
        done = new bool[100];

        ilystart.SetActive(false);

        notif2.SetActive(false);
        notif3.SetActive(false);
        notif4.SetActive(false);
        notif5.SetActive(false);
        notif6.SetActive(false);

        curtime = 0f;

        topSlidePos = slide1.transform.position;
        slidePos2 = slide2.transform.position;
        slidePos3 = slide3.transform.position;
        slidePos4 = slide4.transform.position;

        // response1.SetActive(false);
        // response2.SetActive(false);

        messageplus2.SetActive(false);
        messageplus3.SetActive(false);
        messageplus4.SetActive(false);
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
            if (ilystart.activeInHierarchy)
            {
                response1container.SetActive(true);
                response2container.SetActive(true);
                response3container.SetActive(true);
                response4container.SetActive(true);
                if (!done[0])
                {
                    response1.SetActive(false);
                    response2.SetActive(false);

                    done[0] = true;
                }
                if (response1.activeInHierarchy && !done[1])
                {
                    curtime = Time.time;
                    done[1] = true;
                }
                if (Time.time - curtime > 2f && done[1])
                {
                    notif2.SetActive(true);
                    if (!done[6])
                    {
                        Vector3 slide1pos = slide1.transform.position;
                        if (slide1pos.y > slide2.transform.position.y && slide2.transform.position.y > slide3.transform.position.y)
                        {
                            slide1.transform.position = slide2.transform.position;
                            slide2.transform.position = slide3.transform.position;
                            slide3.transform.position = slide1pos;
                        }
                        else // slide2 > slide 1 > slide 3
                        {
                            slide1.transform.position = slide3.transform.position;
                            slide3.transform.position = slide2.transform.position;
                            slide2.transform.position = slide1pos;

                        }
                        done[6] = true;
                    }
                }
                if (Time.time - curtime > 4f && !option2.activeInHierarchy && done[6] && !done[2])
                {
                    // Debug.Log("message+2");
                    messageplus2.SetActive(true);
                    done[2] = true;
                }
                if (!done[2] || option2.activeInHierarchy)
                {
                    response2.SetActive(false);
                }
                // else
                // {
                //     done[3] = true;
                // }

                if (Time.time - curtime > 15f && response2.activeInHierarchy)
                {
                    notif3.SetActive(true);
                    // done[15] = true;
                    if (!done[4])
                    {
                        done1time = Time.time;
                        done[4] = true;
                    }
                }

                if (done[4] && !backButton.activeInHierarchy)
                {
                    Debug.Log(done[15]);
                    done[15] = true;
                }

                // pt 2
                Debug.Log(" done15? " + done[15]);
                if (Time.time - done1time > 5f && done[15] || done[5]) // should actually = 120f ish
                {
                    if (!backButton.activeInHierarchy && !done[12])
                    {
                        Debug.Log("done13");
                        if (!done[13])
                        {
                            done[13] = true;
                        }
                        ColorChange(notificationtext, 0.1f);
                        UpdateSlidePos(slide3);
                    } else
                    {
                        ColorChange(notificationtext, -notificationtext.color.a);
                    }

                    Debug.Log("pt2");
                    notif2.SetActive(false);
                    // Debug.Log(notif2.activeInHierarchy);
                    notif3.SetActive(false);
                    // Debug.Log(notif3.activeInHierarchy);
                    response1container.SetActive(false);
                    response2container.SetActive(false);

                    if (!done[9] && done[12])
                    {
                        done1time = Time.time;
                        done[9] = true;
                    }

                    if (Time.time - done1time > 7f && done[12] && notif1.activeInHierarchy)
                    {
                        ily.text = "fuck you";
                        notif2.SetActive(false);
                        // Debug.Log(notif2.activeInHierarchy);
                        notif3.SetActive(false);
                        // Debug.Log(notif3.activeInHierarchy);
                        response1container.SetActive(false);
                        response2container.SetActive(false);
                        if (!done[5])
                        {
                            done[5] = true;
                        }
                    }

                    if (Time.time - done1time > 9f && done[5])
                    {
                        if (!done[10])
                        {
                            response3container.SetActive(true);
                            messageplus3.SetActive(true);
                            done[10] = true;
                        }
                    }

                    if (!done[10] || option2.activeInHierarchy)
                    {
                        response3.SetActive(false); // what is wrong with you
                    }
                    if (done[10] && !messageplus3.activeInHierarchy && !option2.activeInHierarchy)
                    {
                        if (!done[7])
                        {
                            done1time = Time.time;
                            done[7] = true;
                        }
                    }

                    if (Time.time - done1time > 2f && done[12] && done[10] && done[7]) 
                    {
                        notif4.SetActive(true); // you piece of shir
                        if (!done[8])
                        {
                            Vector3 slide1pos = slide1.transform.position;
                            if (slide1pos.y > slide2.transform.position.y && slide2.transform.position.y > slide3.transform.position.y)
                            {
                                slide1.transform.position = slide2.transform.position;
                                slide2.transform.position = slide3.transform.position;
                                slide3.transform.position = slide1pos;
                            }
                            else // slide2 > slide 1 > slide 3
                            {
                                slide1.transform.position = slide3.transform.position;
                                slide3.transform.position = slide2.transform.position;
                                slide2.transform.position = slide1pos;

                            }
                            done[8] = true;
                        }
                    }

                    if (Time.time - done1time > 3f && done[7])
                    {
                        notif5.SetActive(true); // shit
                    }

                    if (Time.time - done1time > 6f && done[7])
                    {
                        notif6.SetActive(true); // I wish you would just die
                    }

                    if (Time.time - done1time > 8f && done[7])
                    {
                        if (!done[11])
                        {
                            response4container.SetActive(true);
                            response4.SetActive(true);
                            response4.transform.GetChild(0).gameObject.SetActive(false);
                            response4.transform.GetChild(1).gameObject.SetActive(false);
                            messageplus4.SetActive(true);
                            done[11] = true;
                        }
                    }

                    if (response4.transform.GetChild(0).gameObject.activeInHierarchy ||
                    response4.transform.GetChild(1).gameObject.activeInHierarchy) {
                        done[17] = true;
                    }
                    if (done[8])
                    {
                        response3.SetActive(true);
                    }
                    if (done[17])
                    {
                        response4container.SetActive(true);
                        response4.SetActive(true);
                    }
                    
                }
            }
            else
            {
                notif2.SetActive(false);
                notif3.SetActive(false);
                notif4.SetActive(false);
                notif5.SetActive(false);
                notif6.SetActive(false);
                response1container.SetActive(false);
                response2container.SetActive(false);
                response3.SetActive(false);
                response4.SetActive(false);
            }

            /* if (Time.time - curtime > 15f && done[3])
            {
                Debug.Log(!done[15] + " : " + !backButton.activeInHierarchy);
                if (!done[15] && !backButton.activeInHierarchy)
                {
                    Debug.Log("vrvrvvrvvrvvrvvr");
                    done1time = Time.time;
                    done[15] = true;
                }
            } */
            /* if (!backButton.activeInHierarchy && !done[12])
            {
                Debug.Log("done13");
                if (!done[13])
                {
                    done[13] = true;
                }
                ColorChange(notificationtext, 0.1f);
                UpdateSlidePos();
            } */
            if (phoneBack.activeInHierarchy && done[15] && !done[12])
            {
                Debug.Log("done12");
                ColorChange(notificationtext, -notificationtext.color.a);
                done[12] = true;
            }
        }
    }

    void ColorChange(Text given, float amount)
    {
        Color col = given.color;
        col.a += amount;
        given.color = col;
    }

    void UpdateSlidePos(GameObject slide)
    {
        /* if (topSlidePos == slide1.transform.position)
        {
            slide1.transform.position = slide.transform.position;
        }
        else if (topSlidePos == slide2.transform.position)
        {
            slide2.transform.position = slide.transform.position;
        }
        else if (topSlidePos == slide3.transform.position)
        {
            slide3.transform.position = slide.transform.position;
        }
        else if (topSlidePos == slide4.transform.position)
        {
            slide4.transform.position = slide.transform.position;
        }
        slide.transform.position = topSlidePos; */


        /* if (slide == slide1)
        {
            if (slidePos2 == slide1.transform.position)
            {
                
            } else if (slidePos2 == slide2.transform.position)
            {
                if (slidePos3 == slide3.transform.position)
                {

                } else // (slidePos3 == slide4.transform.position)
                {

                }
            } else if (slidePos2 == slide3.transform.position)
            {

            } else // (slidePos4 == slide3.transform.position)
            {

            }
        } else if (slide == slide2)
        {

        } else if (slide == slide3)
        {

        } else // slide == slide4
        {

        } */
        Vector3 slide1pos = slide1.transform.position;

        if (slide1pos.y > slide2.transform.position.y && slide2.transform.position.y > slide3.transform.position.y) // 1 > 2 > 3
        {
            slide1.transform.position = slide2.transform.position;
            slide2.transform.position = slide3.transform.position;
            slide3.transform.position = slide1pos;
        }
        else if (slide2.transform.position.y > slide1pos.y && slide1pos.y > slide3.transform.position.y) // slide2 > slide 1 > slide 3
        {
            slide1.transform.position = slide3.transform.position;
            slide3.transform.position = slide2.transform.position;
            slide2.transform.position = slide1pos;
        }
        else // slide1 > slide3 > slide2
        {
            slide1.transform.position = slide3.transform.position;
            slide3.transform.position = slide2.transform.position;
            slide2.transform.position = slide1pos;
        } 
    }
}

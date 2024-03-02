using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Threading;

public class Jay : MonoBehaviour
{
    public Text notificationtext;

    public GameObject start;

    // messages
    public GameObject dawg;
    public GameObject alright;

    // 1st responses
    public GameObject notReally;
    public GameObject fine;

    public GameObject glad;
    public GameObject seriously;
    public GameObject life;
    public GameObject vulnerable;
    public GameObject whatsUp;

    // second responses
    public GameObject actuallyFine;
    public GameObject something;

    public GameObject specifically;
    public GameObject saySo;

    // slides
    public GameObject slide1;
    public GameObject slide2;

    // options
    public GameObject noResp;
    public GameObject fineResp;

    public GameObject fineRespTwo;
    public GameObject somethingResp;

    public GameObject message;
    public GameObject messageTwo;

    public GameObject backButton;
    public GameObject phoneBack;

    private bool[] done;
    private bool tutorialcomplete;
    private float curtime;
    private float done1time;
    private float startTime;

    // response vibes
    private bool saidFine;
    private bool saidSomething;
    private bool deadEnd;

    // Start is called before the first frame update
    void Start()
    {
        done = new bool[100];
        curtime = Time.time;

        start.SetActive(false);

        // slide 1
        dawg.SetActive(false);
        alright.SetActive(false);

        // 1st responses
        notReally.SetActive(false);
        fine.SetActive(false);

        glad.SetActive(false);
        seriously.SetActive(false);
        life.SetActive(false);
        vulnerable.SetActive(false);
        whatsUp.SetActive(false);

        // slide 2
        specifically.SetActive(false);
        saySo.SetActive(false);

        // 2nd responses
        actuallyFine.SetActive(false);
        something.SetActive(false);

        // slide 1
        noResp.SetActive(false);
        fineResp.SetActive(false);

        // slide 2
        fineRespTwo.SetActive(false);
        somethingResp.SetActive(false);

        message.SetActive(false);
        messageTwo.SetActive(false);

        // slides
        slide1.SetActive(false);
        slide2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - curtime < 5f && start.activeInHierarchy) {
            start.SetActive(true);
        } else if (start.activeInHierarchy && Time.time - curtime >= 5f && !done[2]) {
            slide1.SetActive(true);
            dawg.SetActive(true);
            if (dawg.activeInHierarchy && slide1.activeInHierarchy && Time.time - curtime > 6f) {
                alright.SetActive(true);
                message.SetActive(true);
                // options
                if ((fine.activeInHierarchy || notReally.activeInHierarchy) && !done[1]) {
                    startTime = Time.time;
                    done[1] = true;
                }

                if (notReally.activeInHierarchy) {
                    saidFine = true;
                    message.SetActive(false);

                    if (Time.time - curtime > startTime + 10f) {
                        vulnerable.SetActive(true);
                    }
                    if (Time.time - curtime > (startTime + 11f)) {
                        whatsUp.SetActive(true);
                        messageTwo.SetActive(true);
                        slide2.SetActive(true);
                    }
                } else if (fine.activeInHierarchy) {
                    saidFine = false;
                    message.SetActive(false);

                    if (Time.time - curtime > startTime + 10f) {
                        glad.SetActive(true);
                    }
                    if (Time.time - curtime > (startTime + 11f)) {
                        seriously.SetActive(true);
                    }
                    if (Time.time - curtime > (startTime + 12f)) {
                        life.SetActive(true);
                        messageTwo.SetActive(true);
                        slide2.SetActive(true);
                    }
                }
            }
            if ((something.activeInHierarchy || actuallyFine.activeInHierarchy) && !done[2]) {
                    disableFirstSlide();
                    startTime = Time.time;
                    done[2] = true;
                    slide2.SetActive(true);
                    messageTwo.SetActive(false);
            }
        } else if (slide2.activeInHierarchy && !done[3]) {
            if (something.activeInHierarchy) {
                deadEnd = false;
                disableFirstSlide();
                slide2.SetActive(true);
                specifically.SetActive(true);
                saySo.SetActive(false);

                if (Time.time - curtime > (startTime + 15f)) {
                    specifically.SetActive(true);
                    done[3] = true;
                }
            } else if (actuallyFine.activeInHierarchy) {
                deadEnd = true;
                disableFirstSlide();
                slide2.SetActive(false);
                saySo.SetActive(true);

                if (Time.time - curtime > (startTime + 15f)) {
                    saySo.SetActive(true);
                    done[3] = true;
                }
            }
        } else {
            disableFirstSlide();
            disableSecondSlide();
            // slide 2
            specifically.SetActive(false);
            saySo.SetActive(false);

            // 2nd responses
            actuallyFine.SetActive(false);
            something.SetActive(false);

            // slide 1
            noResp.SetActive(false);
            fineResp.SetActive(false);

            // slide 2
            fineRespTwo.SetActive(false);
            somethingResp.SetActive(false);

            message.SetActive(false);
            messageTwo.SetActive(false);
        }
    }

    void disableFirstSlide() {
        start.SetActive(false);
        dawg.SetActive(false);
        alright.SetActive(false);
        notReally.SetActive(false);
        fine.SetActive(false);
        noResp.SetActive(false);
        fineResp.SetActive(false);
        message.SetActive(false);
        glad.SetActive(false);
        seriously.SetActive(false);
        life.SetActive(false);
        vulnerable.SetActive(false);
        whatsUp.SetActive(false);
    }

    void disableSecondSlide() {
        saySo.SetActive(false);
        specifically.SetActive(false);
    }

    void ColorChange(Text given, float amount)
    {
        Color col = given.color;
        col.a += amount;
        given.color = col;
    }
}

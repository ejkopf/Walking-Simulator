using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using cse481.logging;

public class Jay : MonoBehaviour {
    public Text notificationText;

    private float curTime;
    private float time;
    private float playerResponseTime;
    private float screenTwoInit;
    // Did the player reply to Jay's most recent message?
    // Topper and backdrop -- should always be active if Jay window is open
    // first
    public GameObject heydawg;
    public GameObject doinalright;
    // second
    public GameObject vulnerable;
    public GameObject whatsUp;
    public GameObject glad;
    public GameObject seriously;
    public GameObject life;
    // third
    public GameObject specifically;
    public GameObject saySo;

    // responses for screen2;
    // first
    public GameObject notreally;
    public GameObject fine;
    // second
    public GameObject something;
    public GameObject actually;
    public GameObject somethingDup;
    public GameObject actuallyDup;
    public GameObject nbd;
    // third
    public GameObject isThatIt;
    public GameObject worried;
    public GameObject dont;
    public GameObject no;
    // fourth
    public GameObject worriedDup;
    public GameObject quick;
    public GameObject bad;
    public GameObject question;
    // options
    public GameObject responseContainer;
    public GameObject responseContainerTwo;
    public GameObject responseContainerThree;
    public GameObject responseContainerFour;
    public GameObject responseContainerFive;
    public GameObject responseContainerSix;

    public GameObject messageTwo;

    // screens
    public GameObject startScreen;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    // public GameObject screen4;

    // progression
    private bool firstJay;
    private bool firstPlayer;
    private bool saidFine;
    private bool saidNotReally;
    private bool secondJay;
    private bool secondPlayer;
    private bool thirdJay;
    private bool entryPoint;
    private bool thirdPlayer;
    private bool fourthJay;
    private bool fourthPlayer;
    private bool fifthJay;
    private bool fifthPlayer;
    private bool sixthJay;
    private bool sixthPlayer;
    private bool seventhJay;
    private bool seventhPlayer;
    // endstate
    private bool deadEnd;
    private bool[] done = new bool[100];

    public GameObject jay;
    public GameObject jay2;
    public GameObject jay3;
    public GameObject jay4;
    public GameObject jay5;
    public GameObject jay6;

    public GameObject goodEnding;

    private CapstoneLogger logger;

    void Start () {
        logger = Logger.Instance.logger;
        string userID = logger.GetSavedUserId();
        if (userID is null || userID is "")
        {
            userID = logger.GenerateUuid();
            logger.SetSavedUserId(userID);
        }

        screenTwoInit = 0f;
        playerResponseTime = 0f;
        time = 1f;

        curTime = Time.time;

        startScreen.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);

        messageTwo.SetActive(false);

        deactivateScreenOne();
        deactivateScreenTwo();
        deactivateScreenThree();
        // deactivateScreenFour();

        firstJay = false;
        firstPlayer = false;
        secondJay = false;
        secondPlayer = false;
        saidFine = false;
        saidNotReally = false;
        thirdJay = false;
        thirdPlayer = false;
        fourthJay = false;
        fourthPlayer = false;
        fifthJay = false;
        fifthPlayer = false;
        sixthJay = false;
        sixthPlayer = false;
        seventhJay = false;
        seventhPlayer = false;
    }
    void Update () {
        if (startScreen.activeInHierarchy) {
            serveCurrentScreen();
        } else {
            deactivateScreenOne();
            deactivateScreenTwo();
            deactivateScreenThree();
            // deactivateScreenFour();
        }
    }

    void serveCurrentScreen() {
        if (!secondPlayer) {
            screen1.SetActive(true);
            handleScreenOneState();
        } else if (secondPlayer && !fourthPlayer) {
            screen2.SetActive(true);
            deactivateScreenOne();
            handleScreenTwoState();
        } else if (fourthPlayer && !seventhJay) {
            screen3.SetActive(true);
            deactivateScreenTwo();
            deactivateScreenOne();
            handleScreenThreeState();
        } else {
            //
        }
    }

    void handleScreenOneState() {
        if (!firstJay) {
            if (jay.activeInHierarchy) { // (Time.time - curTime) > time) {  // CHANGE TO IF JAY ACTIVE IN HIERARCHY
                heydawg.SetActive(true);
                if ((Time.time - curTime) > (time + 2f)) {
                    doinalright.SetActive(true);
                    // 1st Jay message end
                    firstJay = true;
                }
            }
        // if jay messaged but the player hasn't responded yet
        } else if (firstJay && !firstPlayer) {
            responseContainer.SetActive(true);
            heydawg.SetActive(true);
            doinalright.SetActive(true);
            if (notreally.activeInHierarchy || fine.activeInHierarchy) {
                if (!firstPlayer) {
                    firstPlayer = true;
                    if (notreally.activeInHierarchy) {
                        saidNotReally = true;

                        if (!done[51])
                        {
                            logger.LogActionWithNoLevel(25, "said:notreally" + "." + logger.GetSavedUserId());
                            done[51] = true;
                        }
                    } else {
                        saidFine = true;

                        if (!done[52])
                        {
                            logger.LogActionWithNoLevel(26, "said:fine" + "." + logger.GetSavedUserId());
                            done[52] = true;
                        }
                    }
                }
            }
        // if the player responded to the first exchange but jay hasn't replied yet 
        } else if (firstPlayer && !secondJay) { // ADD && JAY2 ACTIVE IN HIERARCHY (hows life/whats up)
            if (!entryPoint) {
                entryPoint = true;
                if (jay2.activeInHierarchy)
                {
                    playerResponseTime = Time.time;
                } else
                {
                    playerResponseTime = 10000000f;
                }
            }
            if (jay2.activeInHierarchy && !done[0])
            {
                playerResponseTime = Time.time - 2f;
                done[0] = true;
            }

            heydawg.SetActive(true);
            doinalright.SetActive(true);
            
            if (notreally.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                vulnerable.SetActive(true);
                if ((Time.time - playerResponseTime) > (time * 2f + 1)) {
                    whatsUp.SetActive(true);
                    secondJay = true;
                }
            } else if (fine.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                glad.SetActive(true);
                if ((Time.time - playerResponseTime) > (time * 2f + 1)) {
                    seriously.SetActive(true);
                    if ((Time.time - playerResponseTime) > (time * 2f + 2)) {
                        life.SetActive(true);
                        secondJay = true;
                    }
                }
            } else if (firstPlayer && saidFine) {
                fine.SetActive(true);
            } else {
                notreally.SetActive(true);
            }
        } else if (secondJay && !secondPlayer) { 
            heydawg.SetActive(true);
            doinalright.SetActive(true);

            if (saidFine) {
                fine.SetActive(true);
                glad.SetActive(true);
                seriously.SetActive(true);
                life.SetActive(true);
            } else {
                notreally.SetActive(true);
                vulnerable.SetActive(true);
                whatsUp.SetActive(true);
            }
            responseContainerTwo.SetActive(true);
            if (something.activeInHierarchy || actually.activeInHierarchy) {
                secondPlayer = true;
                entryPoint = false;
                if (actually.activeInHierarchy) {
                    deadEnd = true;
                    if (!done[53])
                    {
                        logger.LogActionWithNoLevel(27, "said:actuallyfine" + "." + logger.GetSavedUserId());
                        done[53] = true;
                    }
                }
            }
        } else {
            deactivateScreenOne();
        }
    }

    void deactivateScreenOne() {
        heydawg.SetActive(false);
        doinalright.SetActive(false);
        notreally.SetActive(false);
        fine.SetActive(false);
        glad.SetActive(false);
        seriously.SetActive(false);
        life.SetActive(false);
        vulnerable.SetActive(false);
        whatsUp.SetActive(false);
        something.SetActive(false);
        actually.SetActive(false);
        responseContainer.SetActive(false);
        responseContainerTwo.SetActive(false);
        screen1.SetActive(false);
    }

    void deactivateScreenTwo() {
        somethingDup.SetActive(false);
        actuallyDup.SetActive(false);
        specifically.SetActive(false);
        saySo.SetActive(false);
        nbd.SetActive(false);
        responseContainerThree.SetActive(false);
        responseContainerFour.SetActive(false);
        isThatIt.SetActive(false);
        worried.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
    }

    void deactivateScreenThree() {
        worriedDup.SetActive(false);
        dont.SetActive(false);
        no.SetActive(false);
        quick.SetActive(false);
        bad.SetActive(false);
        question.SetActive(false);
        responseContainerFive.SetActive(false);
        responseContainerSix.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
    }
    /*
    void deactivateScreenFour() {
        manyQuestion.SetActive(false);
    }
    */
    void handleScreenTwoState() {
        if (secondPlayer && !thirdJay) { // ADD && JAY3 ACTIVE IN HIERARCHY (if you say so/is that really all)
            if (deadEnd)
            {
                actuallyDup.SetActive(true);
            } else
            {
                somethingDup.SetActive(true);
            }
            if (!entryPoint) {
                entryPoint = true;
                if (jay3.activeInHierarchy)
                {
                    playerResponseTime = Time.time;
                } else
                {
                    playerResponseTime = 10000000f;
                }
            }
            if (jay3.activeInHierarchy && !done[1])
            {
                playerResponseTime = Time.time - 2f;
                done[1] = true;
            }
            if (somethingDup.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                specifically.SetActive(true);
                thirdJay = true;
            } else if (actuallyDup.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                saySo.SetActive(true);
                thirdJay = true;
            }
        } else if (thirdJay && !thirdPlayer) {
            if (!deadEnd) {
                somethingDup.SetActive(true);
                specifically.SetActive(true);
                responseContainerThree.SetActive(true);
                if (nbd.activeInHierarchy)
                {
                    thirdPlayer = true;
                    entryPoint = false;
                }
            } else {
                actuallyDup.SetActive(true);
                saySo.SetActive(true);
            }
        } else if (thirdPlayer && !fourthJay) { // ADD && JAY4 ACTIVE IN HIERARCHY (specifically?)
            if (!entryPoint) {
                if (jay4.activeInHierarchy)
                {
                    playerResponseTime = Time.time;
                }
                else
                {
                    playerResponseTime = 10000000f;
                }
                entryPoint = true;
            }
            if (jay4.activeInHierarchy && !done[2])
            {
                playerResponseTime = Time.time - 2f;
                done[2] = true;
            }
            somethingDup.SetActive(true);
            specifically.SetActive(true);
            if (nbd.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                fourthJay = true;
                entryPoint = false;
            }
        } else if (fourthJay && !fourthPlayer) {
            nbd.SetActive(true);

            if (!done[54])
            {
                logger.LogActionWithNoLevel(28, "said:nbd" + "." + logger.GetSavedUserId());
                done[54] = true;
            }

            isThatIt.SetActive(true);
            responseContainerFour.SetActive(true);
            if (worried.activeInHierarchy) {
                fourthPlayer = true;
            }
        } else {
            deactivateScreenTwo();
        }
    }

    void handleScreenThreeState() {
        if (fourthPlayer && !fifthJay) { // ADD && JAY5 ACTIVE IN HIERARCHY (dont tell me you took her back)
            if (!entryPoint) {
                if (jay5.activeInHierarchy)
                {
                    playerResponseTime = Time.time;
                }
                else
                {
                    playerResponseTime = 10000000f;
                }
                entryPoint = true;
            }
            if (jay5.activeInHierarchy && !done[3])
            {
                playerResponseTime = Time.time - 2f;
                goodEnding.SetActive(true);
                done[3] = true;
            }
            worriedDup.SetActive(true);

            if ((Time.time - playerResponseTime) > (time * 2f)) {
                dont.SetActive(true);
                fifthJay = true;
            }
        } else if (fifthJay && !fifthPlayer) {
            worriedDup.SetActive(true);

            if (!done[55])
            {
                logger.LogActionWithNoLevel(29, "said:worried" + "." + logger.GetSavedUserId());
                done[55] = true;
            }

            dont.SetActive(true);
            responseContainerFive.SetActive(true);
            if (no.activeInHierarchy) {
                no.SetActive(true);
                fifthPlayer = true;
                entryPoint = false;
            }
        } else if (fifthPlayer && !sixthJay) { // responds immediatly cuz why not
            if (!entryPoint) {
                playerResponseTime = Time.time;
                entryPoint = true;
            }
            worriedDup.SetActive(true);
            dont.SetActive(true);
            no.SetActive(true);

            if (!done[56])
            {
                logger.LogActionWithNoLevel(30, "said:no" + "." + logger.GetSavedUserId());
                done[56] = true;
            }

            if ((Time.time - playerResponseTime) > 5f) {
                quick.SetActive(true);
                sixthJay = true;
            }
        } else if (sixthJay && !sixthPlayer) {
            worriedDup.SetActive(true);
            dont.SetActive(true);
            no.SetActive(true);
            quick.SetActive(true);
            responseContainerSix.SetActive(true);
            if (bad.activeInHierarchy) {
                bad.SetActive(true);
                sixthPlayer = true;
                entryPoint = false;
            }
        } else if (sixthPlayer && !seventhJay) { // ADD && JAY6 ACTIVE (???????)
            if (!entryPoint) {
                if (jay6.activeInHierarchy)
                {
                    playerResponseTime = Time.time;
                }
                else
                {
                    playerResponseTime = 10000000f;
                }
                entryPoint = true;
            }
            if (jay6.activeInHierarchy && !done[4])
            {
                playerResponseTime = Time.time - 2f;
                done[4] = true;
            }
            worriedDup.SetActive(true);
            dont.SetActive(true);
            no.SetActive(true);
            quick.SetActive(true);
            bad.SetActive(true);

            if (!done[56])
            {
                logger.LogActionWithNoLevel(31, "said:bad" + "." + logger.GetSavedUserId());
                done[56] = true;
            }

            if ((Time.time - playerResponseTime) > 2f) {
                question.SetActive(true);
                messageTwo.SetActive(false);
                deactivateScreenOne();
                deactivateScreenTwo();
                seventhJay = true;
                entryPoint = false;
            }
        }
    }
    /*
    void handleScreenFourState() {
        if (seventhJay) {
            manyQuestion.SetActive(true);
        } else {
            deactivateScreenFour();
        }
    }
    */
}
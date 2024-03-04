using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class Jay : MonoBehaviour {
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
    public GameObject nbd;
    // third
    public GameObject roommate;
    public GameObject isThatIt;
    public GameObject worried;
    public GameObject dont;
    public GameObject no;
    // fourth
    public GameObject noRepeat;
    public GameObject quick;
    public GameObject bad;
    public GameObject question;
    public GameObject moreQuestion;
    // fifth
    public GameObject manyQuestion;

    // options
    public GameObject responseContainer;
    public GameObject responseContainerTwo;
    public GameObject responseContainerThree;
    public GameObject responseContainerFour;
    public GameObject responseContainerFive;
    public GameObject responseContainerSix;

    // screens
    public GameObject startScreen;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;

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

    void Start () {
        screenTwoInit = 0f;
        playerResponseTime = 0f;
        time = 1f;

        curTime = Time.time;

        startScreen.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);

        deactivateScreenOne();
        deactivateScreenTwo();
        deactivateScreenThree();
        deactivateScreenFour();
        deactivateScreenFive();

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
            screen1.SetActive(true);
            screen2.SetActive(true);
            screen3.SetActive(true);
            screen4.SetActive(true);
            screen5.SetActive(true);
            serveCurrentScreen();
        } else {
            deactivateScreenOne();
            deactivateScreenTwo();
            deactivateScreenThree();
            deactivateScreenFour();
            deactivateScreenFive();
        }
    }

    void serveCurrentScreen() {
        if (!secondPlayer) {
            handleScreenOneState();
        } else if (secondPlayer && !fourthJay) {
            deactivateScreenOne();
            handleScreenTwoState();
        } else if (fourthJay && !fifthPlayer) {
            deactivateScreenTwo();
            handleScreenThreeState();
        } else if (fifthPlayer && !seventhJay) {
            deactivateScreenThree();
            handleScreenFourState();
        } else if (seventhJay) {
            deactivateScreenFour();
            handleScreenFiveState();
        } else {
            // ... 
        }
    }

    void handleScreenOneState() {
        if (!firstJay) {
            if ((Time.time - curTime) > time) {
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
                    } else {
                        saidFine = true;
                    }
                }
            }
        // if the player responded to the first exchange but jay hasn't replied yet
        } else if (firstPlayer && !secondJay) {
            if (!entryPoint) {
                entryPoint = true;
                playerResponseTime = Time.time;
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
        responseContainer.SetActive(false);
        responseContainerTwo.SetActive(false);
    }

    void deactivateScreenTwo() {
        something.SetActive(false);
        actually.SetActive(false);
        specifically.SetActive(false);
        saySo.SetActive(false);
        nbd.SetActive(false);
        responseContainerThree.SetActive(false);
    }

    void deactivateScreenThree() {
        roommate.SetActive(false);
        isThatIt.SetActive(false);
        worried.SetActive(false);
        dont.SetActive(false);
        no.SetActive(false);
        responseContainerFour.SetActive(false);
        responseContainerFive.SetActive(false);
    }

    void deactivateScreenFour() {
        noRepeat.SetActive(false);
        quick.SetActive(false);
        bad.SetActive(false);
        question.SetActive(false);
        moreQuestion.SetActive(false);
        responseContainerSix.SetActive(false);
    }

    void deactivateScreenFive() {
        manyQuestion.SetActive(false);
    }

    void handleScreenTwoState() {
        if (secondPlayer && !thirdJay) {
            if (!entryPoint) {
                entryPoint = true;
                playerResponseTime = Time.time;
            }
            if (something.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                specifically.SetActive(true);
                thirdJay = true;
            } else if (actually.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                saySo.SetActive(true);
                thirdJay = true;
            }
        } else if (thirdJay && !thirdPlayer) {
            if (!deadEnd) {
                something.SetActive(true);
                specifically.SetActive(true);
            } else {
                actually.SetActive(true);
                saySo.SetActive(true);
            }
            responseContainerThree.SetActive(true);
            if (nbd.activeInHierarchy) {
                thirdPlayer = true;
                entryPoint = false;
            }
        } else if (thirdPlayer && !fourthJay) {
            if (!entryPoint) {
                playerResponseTime = Time.time;
                entryPoint = true;
            }
            something.SetActive(true);
            specifically.SetActive(true);
            if (nbd.activeInHierarchy && (Time.time - playerResponseTime) > (time * 2f)) {
                fourthJay = true;
                entryPoint = false;
            }
        } else {
            deactivateScreenTwo();
        }
    }

    void handleScreenThreeState() {
        if (fourthJay && !fourthPlayer) {
            roommate.SetActive(true);
            isThatIt.SetActive(true);
            responseContainerFour.SetActive(true);
            if (worried.activeInHierarchy) {
                fourthPlayer = true;
            }
        } else if (fourthPlayer && !fifthJay) {
            if (!entryPoint) {
                playerResponseTime = Time.time;
                entryPoint = true;
            }
            isThatIt.SetActive(true);
            worried.SetActive(true);
            if ((Time.time - playerResponseTime) > (time * 2f)) {
                dont.SetActive(true);
                fifthJay = true;
            }
        } else if (fifthJay && !fifthPlayer) {
            isThatIt.SetActive(true);
            worried.SetActive(true);
            dont.SetActive(true);
            responseContainerFive.SetActive(true);
            if (no.activeInHierarchy) {
                no.SetActive(true);
                fifthPlayer = true;
                entryPoint = false;
            }
        } else {
            deactivateScreenThree();
        }
    }

    void handleScreenFourState() {
        if (fifthPlayer && !sixthJay) {
            if (!entryPoint) {
                playerResponseTime = Time.time;
                entryPoint = true;
            }
            noRepeat.SetActive(true);
            if ((Time.time - playerResponseTime) > 5f) {
                quick.SetActive(true);
                sixthJay = true;
            }
        } else if (sixthJay && !sixthPlayer) {
            noRepeat.SetActive(true);
            quick.SetActive(true);
            responseContainerSix.SetActive(true);
            if (bad.activeInHierarchy) {
                bad.SetActive(true);
                sixthPlayer = true;
                entryPoint = false;
            }
        } else if (sixthPlayer && !seventhJay) {
            if (!entryPoint) {
                playerResponseTime = Time.time;
                entryPoint = true;
            }
            noRepeat.SetActive(true);
            quick.SetActive(true);
            bad.SetActive(true);
            if ((Time.time - playerResponseTime) > 2f) {
                question.SetActive(true);
            }
            if ((Time.time - playerResponseTime) > 65f) {
                moreQuestion.SetActive(true);
            }
            if ((Time.time - playerResponseTime) > 100f) {
                seventhJay = true;
                entryPoint = false;
            }
        } else {
            deactivateScreenFour();
        }
    }

    void handleScreenFiveState() {
        if (seventhJay) {
            manyQuestion.SetActive(true);
        } else {
            deactivateScreenFive();
        }
    }
}
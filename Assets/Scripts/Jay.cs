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

    // options
    public GameObject responseContainer;
    public GameObject responseContainerTwo;
    // first
    public GameObject optFine;
    public GameObject optNotFine;
    // second
    public GameObject optSomething;
    public GameObject optActually;

    public GameObject startScreen;
    public GameObject screen1;
    public GameObject screen2;

    // progression
    private bool firstJay;
    private bool firstPlayer;
    private bool saidFine;
    private bool saidNotReally;
    private bool secondJay;
    private bool secondPlayer;
    private bool thirdJay;
    private bool entryPoint;
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

        deactivateScreenOne();
        deactivateScreenTwo();

        firstJay = false;
        firstPlayer = false;
        secondJay = false;
        secondPlayer = false;
        saidFine = false;
        saidNotReally = false;
        thirdJay = false;
    }
    void Update () {
        if (startScreen.activeInHierarchy) {
            screen1.SetActive(true);
            screen2.SetActive(true);
            serveCurrentScreen();
        } else {
            deactivateScreenOne();
            deactivateScreenTwo();
        }
    }

    void serveCurrentScreen() {
        if (!secondPlayer) {
            handleScreenOneState();
        } else if (secondPlayer /* && !nthPlayer */) {
            deactivateScreenOne();
            handleScreenTwoState();
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
        optFine.SetActive(false);
        optNotFine.SetActive(false);
        optActually.SetActive(false);
        optSomething.SetActive(false);
    }

    void deactivateScreenTwo() {
        something.SetActive(false);
        actually.SetActive(false);
        specifically.SetActive(false);
        saySo.SetActive(false);
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
        } else if (secondPlayer && thirdJay) {
            if (!deadEnd) {
                something.SetActive(true);
                specifically.SetActive(true);
            } else {
                actually.SetActive(true);
                saySo.SetActive(true);
            }

        } else {
            deactivateScreenTwo();
        }
    }
}
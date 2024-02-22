using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using cse481.logging;

public class Tutorial : MonoBehaviour
{
    public Text notificationtext;
    public Text tutorialtext;

    public GameObject unblockmestart;
    public GameObject unblockmes;
    public GameObject walkbutton;
    public GameObject phonebutton;
    public GameObject homeButtonClick;
    public GameObject backButton;
    public GameObject homeScreen;
    public GameObject response;
    public GameObject option;
    public GameObject messageApp;
    public GameObject tutorialTextContainer;

    private float time;
    private float timesincedone;
    private float initialposition;

    private bool donewith1stinstruction;
    private bool donewith2ndinstruction;
    private bool donewith3rdinstruction;
    private bool donewith4thinstruction;
    private bool done5;
    private bool done6;

    public static CapstoneLogger LOGGER;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        // initialize text
        // Color tempcolor = tutorialtext.GetComponent<MeshRenderer>().material.color;
        // tempcolor.a = 0f;
        // tutorialtext.GetComponent<MeshRenderer>().material.color = tempcolor;
        // notificationtext.GetComponent<MeshRenderer>().material.color = tempcolor;
        ColorChange(tutorialtext, -tutorialtext.color.a);
        ColorChange(notificationtext, -1f);
        // notificationtext.color = zm;

        tutorialtext.text = " Click the \"WALK\" button to WALK.";
        notificationtext.text = " *beep beep!* you have a message!";
        // tutorialtext.SetActive(false);

        donewith1stinstruction = false;
        donewith2ndinstruction = false;
        donewith3rdinstruction = false;
        donewith4thinstruction = false;
        done5 = false;
        done6 = false;

        timesincedone = 0f;
        initialposition = walkbutton.transform.position.z;

        unblockmestart.SetActive(false);
        foreach (Transform child in unblockmes.transform)
        {
            child.gameObject.SetActive(false);
        }

        CapstoneLogger logger = new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        string userID = logger.GetSavedUserId();
        if (userID == null)
        {
            userID = logger.GenerateUuid();
            logger.SetSavedUserId(userID);
        }
        logger.StartNewSession(userID);
        LOGGER = logger;
    }

    // Update is called once per frame
    void Update()
    {
        // fade in walk instruction
        if (Time.time > 2f && walkbutton.activeInHierarchy && !donewith1stinstruction) 
        {
            ColorChange(tutorialtext, 0.05f);
        }

        // notification
        if (walkbutton.transform.position.z > initialposition + 1.5 && !donewith2ndinstruction)
        {
            if (!donewith1stinstruction)
            {
                donewith1stinstruction = true;
                timesincedone = Time.time;
            }
            Debug.Log(Time.time + "," + timesincedone);
            if (Time.time - timesincedone < 3f)
            {
                ColorChange(tutorialtext, -0.05f);
            }
            if (Time.time - timesincedone > 2f && Time.time - timesincedone < 4f)
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (Time.time - timesincedone > 3f)
            {
                tutorialtext.text = " Click the \"PHONE\" button to open your PHONE.";
                ColorChange(tutorialtext, 0.05f);
            }
        }

        // opened phone
        if (homeScreen.activeInHierarchy && !donewith3rdinstruction)
        {
            //backButton.SetActive(false); // checked

            if (!donewith2ndinstruction)
            {
                donewith2ndinstruction = true;
                ColorChange(tutorialtext, -tutorialtext.color.a);
                ColorChange(notificationtext, -notificationtext.color.a);
            }

            tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, 0.5f, tutorialtext.transform.position.z);
            tutorialtext.text = " Click the \"MESSAGES\" icon.";
            ColorChange(tutorialtext, 0.05f);
        } else if (!walkbutton.activeInHierarchy)
        {
            //backButton.SetActive(true); // checked
        }

        // opened messages
        if (!walkbutton.activeInHierarchy && !homeScreen.activeInHierarchy && !donewith4thinstruction && messageApp.activeInHierarchy)
        {
            
            if (!donewith3rdinstruction)
            {
                ColorChange(tutorialtext, -1f);
                donewith3rdinstruction = true;

            }

            homeButtonClick.SetActive(false);
            tutorialtext.text = " Click the first number listed; this is your most recent message.";
            ColorChange(tutorialtext, 0.05f);
        }

        if (tutorialtext.text == " Click the first number listed; this is your most recent message." && homeScreen.activeInHierarchy && !donewith4thinstruction)
        {
            homeScreen.SetActive(false);
            messageApp.SetActive(true);
        }

        // start unblock me sequence
        if (unblockmestart.activeInHierarchy && !done5)
        {
            if (!donewith4thinstruction)
            {
                donewith4thinstruction = true;
                time = Time.time;
                ColorChange(tutorialtext, -tutorialtext.color.a);
            }
            if (Time.time - time > 1f) // revise
            {
                unblockmes.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (Time.time - time > 1.5f)
            {
                unblockmes.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (Time.time - time > 2f)
            {
                unblockmes.transform.GetChild(2).gameObject.SetActive(true);
            }
            if (Time.time - time > 2.5f)
            {
                unblockmes.transform.GetChild(3).gameObject.SetActive(true);
            }
            if (Time.time - time > 3f)
            {
                tutorialtext.text = " You can respond to a message by clicking the PLUS (+) icon.";
                ColorChange(tutorialtext, 0.05f);
            }
        } else if (unblockmestart.activeInHierarchy && done5)
        {
            unblockmes.transform.GetChild(0).gameObject.SetActive(true);
            unblockmes.transform.GetChild(1).gameObject.SetActive(true);
            unblockmes.transform.GetChild(2).gameObject.SetActive(true);
            unblockmes.transform.GetChild(3).gameObject.SetActive(true);
        }

        if (option.activeInHierarchy && donewith4thinstruction)
        {
            if (!donewith4thinstruction) // delete this if statement
            {
                donewith4thinstruction = true;
                time = Time.time;
            }
            if (Time.time - time < 6f)
            {
                ColorChange(tutorialtext, -0.05f);
            }
            if (Time.time - time > 6f)
            {
                tutorialtext.text = " Select a response. There will be more options post tutorial.";
                ColorChange(tutorialtext, 0.05f);
            }
            done5 = true;
        }

        if (response.activeInHierarchy && done5)
        {
            homeButtonClick.SetActive(true);
            done6 = true;
            // backButton.SetActive(true);

            if (Time.time - time < 20f)
            {
                // Debug.Log(Time.time - time + "< 20f");
                ColorChange(tutorialtext, -0.05f);
            }
        }

        if ((done6 && homeScreen.activeInHierarchy) || (done6 && walkbutton.activeInHierarchy)) {
            tutorialTextContainer.SetActive(false);
        }

        if (Time.time - time > 20f)
        {
            float g = Time.time - time;
            // Debug.Log(g + "< 20f");
            tutorialTextContainer.SetActive(false);
        }

        if (!unblockmestart.activeInHierarchy) 
        {
            unblockmes.transform.GetChild(0).gameObject.SetActive(false);
            unblockmes.transform.GetChild(1).gameObject.SetActive(false);
            unblockmes.transform.GetChild(2).gameObject.SetActive(false);
            unblockmes.transform.GetChild(3).gameObject.SetActive(false);
        }

    }

    void ColorChange(Text given, float amount)
    {
        Color col = given.color;
        col.a += amount;
        given.color = col;
    }
}

using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using cse481.logging;

public class Walk : MonoBehaviour
{
    public GameObject phone;
    public GameObject maincamera; // self
    public GameObject walkButton;
    public GameObject clouds;
    public GameObject phoneButton;
    public GameObject back;
    public GameObject fadeToBlack;
    public GameObject container;
    public GameObject call1;
    public GameObject call2;
    public GameObject sunset;

    public Text notificationtext;
    public Text tutorialtext;
    public Text youDied;
    public Text steps;

    public Text s25;
    public Text s50;
    public Text s100;
    public Text s200;
    public Text s300;
    public Text s387;

    // public Text steps;

    private float stepcount;
    private bool end;
    private float time;

    private CapstoneLogger logger;

    // Start is called before the first frame update
    void Start()
    {
        Color tempcolor = fadeToBlack.GetComponent<MeshRenderer>().material.color;
        tempcolor.a -= tempcolor.a;
        fadeToBlack.GetComponent<MeshRenderer>().material.color = tempcolor;

        tempcolor = youDied.color;
        tempcolor.a -= tempcolor.a;
        youDied.color = tempcolor;

        fadeToBlack.SetActive(false);

        end = false;
        time = 0;

        SetStartPos(phone);
        SetStartPos(maincamera);
        SetStartPos(walkButton);
        SetStartPos(clouds);
        SetStartPos(phoneButton);
        SetStartPos(back);
        SetStartPos(fadeToBlack);
        SetStartPos(container);
        SetStartPos(call1);
        SetStartPos(call2);
        SetStartPos(sunset);

        tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, tutorialtext.transform.position.y, tutorialtext.transform.position.z + 300f);
        notificationtext.transform.position = new Vector3(notificationtext.transform.position.x, notificationtext.transform.position.y, notificationtext.transform.position.z + 300f);

        logger = Logger.Instance.logger;
        string userID = logger.GetSavedUserId();
        if (userID is null || userID is "")
        {
            userID = logger.GenerateUuid();
            logger.SetSavedUserId(userID);
        }
        logger.StartNewSession(userID);
    }

    // Update is called once per frame
    void Update()
    {
        if (call2.activeInHierarchy)
        {
            call1.SetActive(false);
        }

        steps.text = stepcount.ToString();

        if (stepcount >= 25f)
        {
            s25.text = "25 steps - unlocked";
        }
        if (stepcount >= 50f)
        {
            s50.text = "50 steps - unlocked";
        }
        if (stepcount >= 100f)
        {
            s100.text = "100 steps - unlocked";
        }
        if (stepcount >= 200f)
        {
            s200.text = "200 steps - unlocked";
        }
        if (stepcount >= 300f)
        {
            s300.text = "300 steps - unlocked";
        }
        if (stepcount >= 300f)
        {
            s387.text = "387 steps - unlocked";
        }

        if (walkButton.transform.position.z > 592f)
        {
            fadeToBlack.SetActive(true);
            Color tempcolor = fadeToBlack.GetComponent<MeshRenderer>().material.color;
            tempcolor.a = 1f;
            fadeToBlack.GetComponent<MeshRenderer>().material.color = tempcolor;

            /* tempcolor = fadeToBlack.GetComponent<MeshRenderer>().material.color;
            tempcolor.a -= 0.01f;
            walkButton.GetComponent<MeshRenderer>().material.color = tempcolor; */
        }
        if (fadeToBlack.GetComponent<MeshRenderer>().material.color.a >= 1f && !end)
        {
            if (!end)
            {
                // logger.LogLevelEnd("end");
                end = true;
                time = Time.time;
            }
        }
        if (Time.time - time > 2f && end)
        {
            Color tempcolor = youDied.color;
            tempcolor.a += 0.005f;
            youDied.color = tempcolor;
        }
    }

    void OnMouseDown()
    {
        logger.LogActionWithNoLevel(0, "walk" + "." + logger.GetSavedUserId());

        stepcount++;

        UpdatePosition(phone);
        UpdatePosition(maincamera);
        UpdatePosition(walkButton);
        UpdatePosition(clouds);
        UpdatePosition(phoneButton);
        UpdatePosition(back);
        UpdatePosition(fadeToBlack);
        UpdatePosition(container);
        UpdatePosition(call1);
        UpdatePosition(call2);
        UpdatePosition(sunset);

        if (stepcount >= 0)
        {
            tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, tutorialtext.transform.position.y, tutorialtext.transform.position.z + 0.8f);
            notificationtext.transform.position = new Vector3(notificationtext.transform.position.x, notificationtext.transform.position.y, notificationtext.transform.position.z + 0.8f);
            // youDied.transform.position = new Vector3(youDied.transform.position.x, youDied.transform.position.y, youDied.transform.position.z + 0.5f);
        }
        else
        {
            tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, tutorialtext.transform.position.y, tutorialtext.transform.position.z + 580f);
            notificationtext.transform.position = new Vector3(notificationtext.transform.position.x, notificationtext.transform.position.y, notificationtext.transform.position.z + 580f);
            // youDied.transform.position = new Vector3(youDied.transform.position.x, youDied.transform.position.y, youDied.transform.position.z + 580f);
        }
    }

    void SetStartPos(GameObject obj)
    {
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 300f);
    }

    void UpdatePosition(GameObject obj)
    {
        if (stepcount >= 0)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 0.8f);
        } else
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 580f);
        }
    }
}
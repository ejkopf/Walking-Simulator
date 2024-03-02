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

    public Text notificationtext;
    public Text tutorialtext;
    public Text youDied;
    public Text steps;

    private float stepcount;
    private bool end;
    private float time;

    private CapstoneLogger logger;
    // Start is called before the first frame update
    void Start()
    {
        CapstoneLogger logger = new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        this.logger = logger;

        Color tempcolor = fadeToBlack.GetComponent<MeshRenderer>().material.color;
        tempcolor.a -= tempcolor.a;
        fadeToBlack.GetComponent<MeshRenderer>().material.color = tempcolor;

        tempcolor = youDied.color;
        tempcolor.a -= tempcolor.a;
        youDied.color = tempcolor;

        fadeToBlack.SetActive(false);

        end = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        steps.text = stepcount.ToString();
        if (walkButton.transform.position.z > 592f)
        {
            fadeToBlack.SetActive(true);
            Color tempcolor = fadeToBlack.GetComponent<MeshRenderer>().material.color;
            tempcolor.a += 0.001f;
            fadeToBlack.GetComponent<MeshRenderer>().material.color = tempcolor;

            /* tempcolor = fadeToBlack.GetComponent<MeshRenderer>().material.color;
            tempcolor.a -= 0.01f;
            walkButton.GetComponent<MeshRenderer>().material.color = tempcolor; */
        }
        if (fadeToBlack.GetComponent<MeshRenderer>().material.color.a >= 1f && !end)
        {
            if (!end)
            {
                logger.LogLevelEnd("end");
                end = true;
                time = Time.time;
            }
        }
        if (Time.time - time > 2f && end)
        {
            Color tempcolor = youDied.color;
            tempcolor.a += 0.0005f;
            youDied.color = tempcolor;
        }
    }

    void OnMouseDown()
    {
        logger.LogActionWithNoLevel(0, "walk");
        stepcount++;
        UpdatePosition(phone);
        UpdatePosition(maincamera);
        UpdatePosition(walkButton);
        UpdatePosition(clouds);
        UpdatePosition(phoneButton);
        UpdatePosition(back);
        UpdatePosition(fadeToBlack);
        
        if (stepcount >= 0)
        {
            tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, tutorialtext.transform.position.y, tutorialtext.transform.position.z + 0.5f);
            notificationtext.transform.position = new Vector3(notificationtext.transform.position.x, notificationtext.transform.position.y, notificationtext.transform.position.z + 0.5f);
            youDied.transform.position = new Vector3(youDied.transform.position.x, youDied.transform.position.y, youDied.transform.position.z + 0.5f);
        }
        else
        {
            tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, tutorialtext.transform.position.y, tutorialtext.transform.position.z + 580f);
            notificationtext.transform.position = new Vector3(notificationtext.transform.position.x, notificationtext.transform.position.y, notificationtext.transform.position.z + 580f);
            youDied.transform.position = new Vector3(youDied.transform.position.x, youDied.transform.position.y, youDied.transform.position.z + 580f);
        }
    }

    void UpdatePosition(GameObject obj)
    {
        if (stepcount >= 0)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 0.5f);
        } else
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 580f);
        }
    }
}
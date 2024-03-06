using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using cse481.logging;

public class Game : MonoBehaviour
{
    public Text notificationtext;
    public Text steps;
    public GameObject roomie;
    public GameObject roomiep2;
    public GameObject ilyp2;
    public GameObject jay;
    public GameObject jay2;
    public GameObject jay3;
    public GameObject jay4;
    public GameObject jay5;
    public GameObject jay6;
    public GameObject excall;
    public GameObject jaycall;
    public GameObject goodEnding;
    public GameObject phoneBack;

    private CapstoneLogger logger;

    private bool[] done;

    // Start is called before the first frame update
    void Start()
    {
        done = new bool[100];

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
        int stepCount = 0;
        int.TryParse(steps.text, out stepCount);
        if (stepCount > 25)
        {
            // roommate texts start
            roomie.SetActive(true);

            if (!done[50])
            {
                logger.LogActionWithNoLevel(14, "roomiestart" + "." + logger.GetSavedUserId());
                done[50] = true;
            }
        }
        if (stepCount > 50)
        {
            // roommate pt 2
            roomiep2.SetActive(true);

            if (!done[51])
            {
                logger.LogActionWithNoLevel(15, "roomiep2start" + "." + logger.GetSavedUserId());
                done[51] = true;
            }
        }
        if (stepCount > 75)
        {
            // jay texts start
            jay.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[0])
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[0])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[0] = true;
            }

            if (!done[52])
            {
                logger.LogActionWithNoLevel(16, "jaytextsstart" + "." + logger.GetSavedUserId());
                done[52] = true;
            }
        }
        if (stepCount > 100)
        {
            // jay texts start
            jay2.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[1])
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[1])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[1] = true;
            }

            if (!done[53])
            {
                logger.LogActionWithNoLevel(17, "jaytexts2start" + "." + logger.GetSavedUserId());
                done[53] = true;
            }
        }
        if (stepCount > 125)
        {
            // jay texts start
            jay3.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[2])
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[2])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[2] = true;
            }

            if (!done[54])
            {
                logger.LogActionWithNoLevel(18, "jaytexts3start" + "." + logger.GetSavedUserId());
                done[54] = true;
            }
        }
        if (stepCount > 175)
        {
            // jay texts start
            jay3.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[3])
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[3])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[3] = true;
            }

            if (!done[55])
            {
                done[55] = true;
            }
        }
        if (stepCount > 150)
        {
            // jay texts start
            jay4.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[4])
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[4])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[4] = true;
            }

            if (!done[56])
            {
                logger.LogActionWithNoLevel(19, "jaytexts4start" + "." + logger.GetSavedUserId());
                done[56] = true;
            }
        }
        if (stepCount > 200)
        {
            // ily pt 2
            ilyp2.SetActive(true);

            if (!done[57])
            {
                logger.LogActionWithNoLevel(20, "ilyp2start" + "." + logger.GetSavedUserId());
                done[57] = true;
            }
        }
        if (stepCount > 250)
        {
            // jay texts start
            jay5.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[5])
            {
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[5])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[5] = true;
            }

            if (!done[58])
            {
                logger.LogActionWithNoLevel(21, "jaytexts5start" + "." + logger.GetSavedUserId());
                done[58] = true;
            }
        }
        if (stepCount > 300)
        {
            // ex call start
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[6])
            {
                notificationtext.text = "776-9**-**** is calling";
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[6])
            {
                logger.LogActionWithNoLevel(22, "call1" + "." + logger.GetSavedUserId());
                ColorChange(notificationtext, -notificationtext.color.a);
                done[6] = true;
            }
            else if (done[6] && !done[8])
            {
                excall.SetActive(true);
                done[8] = true;
            }
        }
        if (stepCount > 340)
        {
            // jay texts start
            jay6.SetActive(true);
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[7])
            {
                notificationtext.text = "*beep beep!* you have a message!";
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[7])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                done[7] = true;
            }

            if (!done[59])
            {
                logger.LogActionWithNoLevel(23, "jaytexts6start" + "." + logger.GetSavedUserId());
                done[59] = true;
            }
        }
        if (stepCount > 380 && goodEnding.activeInHierarchy)
        {
            // jay call start
            if (!phoneBack.activeInHierarchy && notificationtext.color.a <= 1f && !done[10])
            {
                notificationtext.text = "JAY is calling";
                ColorChange(notificationtext, 0.1f);
            }
            if (phoneBack.activeInHierarchy && !done[10])
            {
                ColorChange(notificationtext, -notificationtext.color.a);
                logger.LogActionWithNoLevel(24, "call2" + "." + logger.GetSavedUserId());
                done[10] = true;
            }
            else if (done[10] && !done[9])
            {
                jaycall.SetActive(true);
                done[9] = true;
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

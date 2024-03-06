using System.Collections;
using System.Collections.Generic;
using cse481.logging;
using UnityEngine;
using UnityEngine.EventSystems;

public class Phone : MonoBehaviour
{
    public GameObject back;
    public GameObject phoneBack;
    public GameObject homeScreen;
    public GameObject app1;
    public GameObject app2;
    public GameObject app3;
    public GameObject app4;
    public GameObject app5;
    public GameObject app6;
    public GameObject app7;
    public GameObject app8;
    public GameObject app9;
    public GameObject app10;
    public GameObject app11;
    public GameObject app12;
    public GameObject app13;
    public GameObject app14;
    public GameObject app15;
    public GameObject app16;
    public GameObject small;
    public GameObject enlarged;
    public GameObject app17;

    // Jay stuff
    public GameObject jayStart;
    public GameObject jayScreen1;
    public GameObject jayScreen2;
    public GameObject jayScreen3;
    public GameObject jayScreen4;

    public GameObject response1;
    public GameObject response2;
    public GameObject response3;
    public GameObject response4;
    public GameObject response5;
    public GameObject response6;

    private CapstoneLogger logger;

    private bool[] open = new bool[100];

    // Start is called before the first frame update
    void Start()
    {
        logger = Logger.Instance.logger;
        string userID = logger.GetSavedUserId();
        if (userID is null || userID is "")
        {
            userID = logger.GenerateUuid();
            logger.SetSavedUserId(userID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (phoneBack.activeInHierarchy && !app1.activeInHierarchy
            && !app2.activeInHierarchy && !app3.activeInHierarchy && !app4.activeInHierarchy && !app5.activeInHierarchy
            && !app6.activeInHierarchy && !app8.activeInHierarchy && !app7.activeInHierarchy && !app9.activeInHierarchy
            && !app10.activeInHierarchy && !app11.activeInHierarchy && !app12.activeInHierarchy && !app13.activeInHierarchy
            && !app14.activeInHierarchy && !app15.activeInHierarchy
            && !app16.activeInHierarchy && !app17.activeInHierarchy
            && !jayStart.activeInHierarchy && !jayScreen1.activeInHierarchy
            && !jayScreen2.activeInHierarchy && !jayScreen3.activeInHierarchy && !jayScreen4.activeInHierarchy
            && !response1.activeInHierarchy && !response2.activeInHierarchy && !response3.activeInHierarchy
            && !response4.activeInHierarchy && !response5.activeInHierarchy && !response6.activeInHierarchy)
        {
            homeScreen.SetActive(true);
        }
        if (!phoneBack.activeInHierarchy)
        {
            // back.SetActive(false);
            homeScreen.SetActive(false);
            app1.SetActive(false);
            app2.SetActive(false);
            app3.SetActive(false);
            app4.SetActive(false);
            app5.SetActive(false);
            app6.SetActive(false);
            app7.SetActive(false);
            app8.SetActive(false);
            app9.SetActive(false);
            app10.SetActive(false);
            app11.SetActive(false);
            app12.SetActive(false);
            app13.SetActive(false);
            app14.SetActive(false);
            app15.SetActive(false);
            app16.SetActive(false);
            foreach (Transform child in enlarged.transform)
            {
                child.gameObject.SetActive(false);
            }
            small.SetActive(true);
            app17.SetActive(false);

            jayStart.SetActive(false);
            jayScreen1.SetActive(false);
            jayScreen2.SetActive(false);
            jayScreen3.SetActive(false);
            jayScreen4.SetActive(false);

            response6.SetActive(false);
            response5.SetActive(false);
            response4.SetActive(false);
            response3.SetActive(false);
            response2.SetActive(false);
            response1.SetActive(false);

        }

        // logging apps
        if (app1.activeInHierarchy && !open[1])
        {
            logger.LogActionWithNoLevel(50, "open:messages" + "." + logger.GetSavedUserId());
            open[1] = true;
        }
        if (homeScreen.activeInHierarchy || !phoneBack.activeInHierarchy)
        {
            open[1] = false;
        }

        if (app10.activeInHierarchy && !open[10])
        {
            logger.LogActionWithNoLevel(51, "open:notes" + "." + logger.GetSavedUserId());
            open[10] = true;
        }
        if (homeScreen.activeInHierarchy || !phoneBack.activeInHierarchy)
        {
            open[10] = false;
        }

        if (app9.activeInHierarchy && !open[9])
        {
            logger.LogActionWithNoLevel(52, "open:steps" + "." + logger.GetSavedUserId());
            open[9] = true;
        }
        if (homeScreen.activeInHierarchy || !phoneBack.activeInHierarchy)
        {
            open[9] = false;
        }

        if (app17.activeInHierarchy && !open[17])
        {
            logger.LogActionWithNoLevel(53, "open:photos" + "." + logger.GetSavedUserId());
            open[17] = true;
        }
        if (homeScreen.activeInHierarchy || !phoneBack.activeInHierarchy)
        {
            open[17] = false;
        }

        if (app5.activeInHierarchy && !open[5])
        {
            logger.LogActionWithNoLevel(53, "open:calls" + "." + logger.GetSavedUserId());
            open[5] = true;
        }
        if (homeScreen.activeInHierarchy || !phoneBack.activeInHierarchy)
        {
            open[5] = false;
        }
    }
}

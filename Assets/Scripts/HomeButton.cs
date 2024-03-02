using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using cse481.logging;

public class HomeButton : MonoBehaviour
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
    public GameObject app17;
    public GameObject small;
    public GameObject enlarged;
    private CapstoneLogger logger;

    // Start is called before the first frame update
    void Start()
    {
        CapstoneLogger logger = new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        this.logger = logger;
    }

    // Update is called once per frame
    void Update()
    {
        if (phoneBack.activeInHierarchy && !app1.activeInHierarchy && !app2.activeInHierarchy && !app3.activeInHierarchy
            && !app4.activeInHierarchy && !app5.activeInHierarchy && !app6.activeInHierarchy && !app8.activeInHierarchy
            && !app7.activeInHierarchy && !app9.activeInHierarchy && !app10.activeInHierarchy && !app11.activeInHierarchy
            && !app12.activeInHierarchy && !app13.activeInHierarchy && !app14.activeInHierarchy && !app15.activeInHierarchy
            && !app16.activeInHierarchy && !app17.activeInHierarchy) {
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
            foreach (Transform child in enlarged.transform) {
                child.gameObject.SetActive(false);
            }
            small.SetActive(true);
            app17.SetActive(false);
        }

    }

    void OnMouseDown()
    {
        // logger.LogActionWithNoLevel(1, "home button");
        homeScreen.SetActive(true);
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
    }
}

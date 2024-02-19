using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phoneBack.activeInHierarchy && !app1.activeInHierarchy && !app2.activeInHierarchy && !app3.activeInHierarchy
            && !app4.activeInHierarchy && !app5.activeInHierarchy && !app6.activeInHierarchy && !app8.activeInHierarchy
            && !app7.activeInHierarchy && !app9.activeInHierarchy && !app10.activeInHierarchy && !app11.activeInHierarchy) {
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
        }

    }

    void OnMouseDown()
    {
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

    }
}

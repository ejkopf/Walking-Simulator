using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Text tutorialText;
    public GameObject textContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > 10) // && player hasnt clicked walk
        {
            // fade in
            tutorialText.text = "Click the \"WALK\" button to move forward.";
        }
        // next if
        // send notif: *beep beep!* you got a text!
        tutorialText.text = "Click the \"Phone\" button to look at your phone.";
    }
}

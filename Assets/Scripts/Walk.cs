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

    public Text notificationtext;
    public Text tutorialtext;
    public Text steps;

    private float stepcount;

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
        steps.text = stepcount.ToString();
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
        tutorialtext.transform.position = new Vector3(tutorialtext.transform.position.x, tutorialtext.transform.position.y, tutorialtext.transform.position.z + 0.5f);
        notificationtext.transform.position = new Vector3(notificationtext.transform.position.x, notificationtext.transform.position.y, notificationtext.transform.position.z + 0.5f);
    }

    void UpdatePosition(GameObject obj) => obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 0.5f);
}

using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        steps.text = stepcount.ToString();
    }

    void OnMouseDown()
    {
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

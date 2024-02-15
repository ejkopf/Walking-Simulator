using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public GameObject phone;
    public GameObject camera; // self
    public GameObject walkButton;
    public GameObject clouds;
    public GameObject phoneButton;
    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        UpdatePosition(phone);
        UpdatePosition(camera);
        UpdatePosition(walkButton);
        UpdatePosition(clouds);
        UpdatePosition(phoneButton);
        UpdatePosition(back);
    }

    void UpdatePosition(GameObject obj) => obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 0.5f);
}

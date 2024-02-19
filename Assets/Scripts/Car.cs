using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour
{
    public GameObject car;
    public GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z + 0.15f);
        if (car.transform.position.z > maincamera.transform.position.z + 18f)
        {
            // Debug.Log(car.transform.position.z + ", " + maincamera.transform.position.z);
            Color tempcolor = car.GetComponent<MeshRenderer>().material.color;
            tempcolor.a -= 0.0075f;
            car.GetComponent<MeshRenderer>().material.color = tempcolor;
        }
        if (car.transform.position.z > maincamera.transform.position.z + 33f)
        {
            car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, maincamera.transform.position.z - 2f);
            Color tempcolor = car.GetComponent<MeshRenderer>().material.color;
            tempcolor.a = 1.0f;
            car.GetComponent<MeshRenderer>().material.color = tempcolor;
        }
    }
}

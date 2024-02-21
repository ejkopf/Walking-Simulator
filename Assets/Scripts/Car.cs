using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour
{
    public GameObject car;
    // put in groups?
    public GameObject carsgoingleft1;
    public GameObject carsgoingright1;

    float initposcar;
    float initialposleft;
    float initialposright;

    public GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        initposcar = car.transform.position.x;
        if (initposcar < 0)
        {
            car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, maincamera.transform.position.z + 33f);
        }
        initialposleft = carsgoingleft1.transform.position.x;
        initialposright = carsgoingright1.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (initposcar > 0)
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
        else
        {
            car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z - 0.15f);
            if (car.transform.position.z < maincamera.transform.position.z - 2f)
            {
                // Debug.Log(car.transform.position.z + ", " + maincamera.transform.position.z);
                Color tempcolor = car.GetComponent<MeshRenderer>().material.color;
                tempcolor.a = 0f;
                car.GetComponent<MeshRenderer>().material.color = tempcolor;
                car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, maincamera.transform.position.z + 33f);
            }
            if (car.transform.position.z > maincamera.transform.position.z - 2f)
            {
                Color tempcolor = car.GetComponent<MeshRenderer>().material.color;
                if (tempcolor.a <= 1f)
                {
                    tempcolor.a += 0.0075f;
                }
                car.GetComponent<MeshRenderer>().material.color = tempcolor;
            }
        }

        
        carsgoingleft1.transform.position = new Vector3(carsgoingleft1.transform.position.x - 0.5f, carsgoingleft1.transform.position.y, carsgoingleft1.transform.position.z );
        if (carsgoingleft1.transform.position.x < initialposleft - 20f)
        {
            carsgoingleft1.transform.position = new Vector3(carsgoingleft1.transform.position.x + 40f, carsgoingleft1.transform.position.y, carsgoingleft1.transform.position.z);
        }

        
        carsgoingright1.transform.position = new Vector3(carsgoingright1.transform.position.x + 0.5f, carsgoingright1.transform.position.y, carsgoingright1.transform.position.z );
        if (carsgoingright1.transform.position.x > initialposright + 20f)
        {
            carsgoingright1.transform.position = new Vector3(carsgoingright1.transform.position.x - 40f, carsgoingright1.transform.position.y, carsgoingright1.transform.position.z );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cse481.logging;

public class Logger : MonoBehaviour
{
    public CapstoneLogger logger;
    private static Logger _instance;
    public static Logger Instance
    {
        get { 
            if (_instance == null)
            {
                Debug.Log("Logger is null");
            }
            return _instance; 
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        logger =  new CapstoneLogger(20240109, "walkingsim", "860d0f1dd48e31e2fb5898f5e1cb101d", 1);
        Debug.Log("Logger is online and available");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

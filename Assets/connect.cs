using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class connect : MonoBehaviour {
    public string portName = "COM5";
    public int baundRate = 9600;
    private SerialPort mySerial;
    // Use this for initialization
    void Start () {
        mySerial = new SerialPort(portName, baundRate);
        mySerial.Open();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) {
            mySerial.Write("a");
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            mySerial.Write("e");
        }
		
	}
}

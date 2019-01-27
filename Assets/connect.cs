using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class connect : MonoBehaviour {
    public string portName = "COM5";
    public int baundRate = 9600;
    private SerialPort mySerial;
    private Thread mythread;
    string[] message;
    public GameObject cube;

    void Read() {
        while (mySerial.IsOpen) {
            message = mySerial.ReadLine().Split(',');
        }
    }
    void Start () {
        mySerial = new SerialPort(portName, baundRate);
        mySerial.Open();
        mythread = new Thread(Read);
        mythread.Start();
	}
 
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKey(KeyCode.A)) {
            mySerial.Write("a");
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            mySerial.Write("e");
        }*/
        int a = int.Parse(message[0]);
        if(a > 10) {
            if (cube.activeSelf) {
                cube.SetActive(false);
            } else {
                cube.SetActive(true);
            }
        }
        Debug.Log(a);
		
	}
    private void OnDestroy() {
        mySerial.Close();
        mySerial.Dispose();
    }
}

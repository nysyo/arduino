using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialSample: MonoBehaviour {
    private SerialPortWrapper _serialPort;

    int p;
    string s;
    void Awake() {
        _serialPort = new SerialPortWrapper("COM5", 9600);
    }

    private void OnDisable() {
        _serialPort.KillThread();
    }

    void Update() {
        p = (int)Input.mousePosition.x / 4;
        if (Input.GetMouseButton(0)) {
            Debug.Log(p);
            s = p.ToString();
            _serialPort.Write(s);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cymove1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform cameraTrans = GameObject.Find("Cylinder1").transform;
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = cameraTrans.position;
            pos.z = pos.z + 0.1f;
            cameraTrans.position = pos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 pos = cameraTrans.position;
            pos.z = pos.z - 0.1f;
            cameraTrans.position = pos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = cameraTrans.position;
            pos.x = pos.x + 0.1f;
            cameraTrans.position = pos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = cameraTrans.position;
            pos.x = pos.x - 0.1f;
            cameraTrans.position = pos;
        }



    }
}

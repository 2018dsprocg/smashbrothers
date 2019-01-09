using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cymove2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey("up"))
        //{
        //    Vector3 mv = new Vector3(0.1f, 0f, 0f);
        //    transform.Translate(mv);
        //}
        Transform cameraTrans = GameObject.Find("Cylinder2").transform;
        if (Input.GetKey("up"))
        {
            Vector3 pos = cameraTrans.position;
            pos.z = pos.z + 0.1f;
            cameraTrans.position = pos;
        }
        if (Input.GetKey("down"))
        {
            Vector3 pos = cameraTrans.position;
            pos.z = pos.z - 0.1f;
            cameraTrans.position = pos;
        }
        if (Input.GetKey("right"))
        {
            Vector3 pos = cameraTrans.position;
            pos.x = pos.x + 0.1f;
            cameraTrans.position = pos;
        }
        if (Input.GetKey("left"))
        {
            Vector3 pos = cameraTrans.position;
            pos.x = pos.x - 0.1f;
            cameraTrans.position = pos;
        }

    }
}

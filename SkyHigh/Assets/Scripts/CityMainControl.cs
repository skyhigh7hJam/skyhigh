using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMainControl : MonoBehaviour {

    public GameObject looktarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        Camera.main.transform.position = new Vector3(
            Camera.main.transform.position.x,
Mathf.Sin(Time.time*0.25f)*4f+10f,
Camera.main.transform.position.z

            );*/
        Camera.main.transform.LookAt(looktarget.transform);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinger : MonoBehaviour {

    static bool fortSwing = true;
    private float decree = 1;
    private float posValue = 0;
    float speed = 0.5f;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector3(posValue, transform.position.y, transform.position.z);

        if (fortSwing == true)
        {
            posValue += Time.deltaTime*speed;
        }

        else
        {
            posValue -= Time.deltaTime * speed;
        }

        if (posValue >= decree)
        {
            fortSwing = false;
        }

        else if (posValue <= -decree)
        {
            fortSwing = true;
        }
        //GetComponent<Transform>().rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3(0,0,5)), Time.deltaTime*0.1f);
    }
}

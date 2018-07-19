using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {

    private GameObject c1;
    private GameObject c2;
    private GameObject c3;

	// Use this for initialization
	void Start () {
        c1 = this.transform.Find("silho1").gameObject;
        c2 = this.transform.Find("silho2").gameObject;
        c3 = this.transform.Find("silho3").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        c1.transform.localPosition = new Vector3(c1.transform.localPosition.x,
            1.61f + (Camera.main.transform.position.y-1f)*0.1f ,
            c1.transform.localPosition.z);
        c2.transform.localPosition = new Vector3(c2.transform.localPosition.x,
            4.2f + (Camera.main.transform.position.y - 1f) * 0.2f,
            c2.transform.localPosition.z);
        c3.transform.localPosition = new Vector3(c3.transform.localPosition.x,
                    6.6f + (Camera.main.transform.position.y - 1f) * 0.3f,
                    c3.transform.localPosition.z);

    }
}

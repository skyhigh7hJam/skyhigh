using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour {

    public static float camTarget = 0f;
    public static int score = 0;
    public static bool ended = false;

    public GameObject highscore;

	// Use this for initialization
	void Start () {
        camTarget = 0f;
        score = 0;
        ended = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

        GameObject.Find("Canvas/Panel/Score").GetComponent<Text>().text = score.ToString();
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 
            Camera.main.transform.position.y+ (camTarget+1f - Camera.main.transform.position.y)/50f, 
            -2f);
    }

    public void showEnd()
    {
        SoundControl.instance.playHighscore();
        highscore.SetActive(true);
    }
}

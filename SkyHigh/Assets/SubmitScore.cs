﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour {

    public int Score;

    private GameObject submit;

	// Use this for initialization
	void Start () {
        submit = this.transform.Find("Panel/submit").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Find("Panel/score").GetComponent<Text>().text = Score.ToString();
	}

    public void enableSave(int score)
    {
        this.Score = score;
        submit.SetActive(true);
    }

    public void submitScore()
    {
        var name = this.transform.Find("Panel/name/Text").GetComponent<Text>().text;
        this.GetComponent<Highscore>().Submit(name, Score);
        submit.SetActive(false);
    }
}
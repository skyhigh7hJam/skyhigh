﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private static bool first = true;
    private static int score = 0;
    bool active = true;
    private bool isFirst = false;
    static float targetY = 1f;

    // Use this for initialization
    void Start()
    {
        score = 0;
        
        isFirst = first;
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirst)
            Camera.main.transform.position = new Vector2(Camera.main.transform.position.x, targetY);// (targetY - Camera.main.transform.position.y)/50f);
    }

    void OnCollisionEnter2D(Collision2D colz)
    {
        if (colz.gameObject.tag == "BBlock" && active == true)
        {
            active = false;
            targetY += 0.5f;
            score += (int)Mathf.Floor(30 + UnityEngine.Random.value * 70);
            GameObject.Find("Canvas/Panel/Score").GetComponent<Text>().text = score.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LBorder" || other.gameObject.name == "RBorder")
        {
            Debug.Log("Game Over");
                SubmitScore.Score = score;
                UnityEngine.SceneManagement.SceneManager.LoadScene("score_save");
                
            
        }
    }
}

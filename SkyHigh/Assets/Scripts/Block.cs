using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    bool active = true;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D colz)
    {
        if (colz.gameObject.tag == "BBlock" && active == true)
        {
            active = false;
            MainControl.camTarget += 0.65f;
            MainControl.score += (int)Mathf.Floor(30 + UnityEngine.Random.value * 70);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LBorder" || other.gameObject.name == "RBorder")
        {
            MainControl.ended = true;
            Debug.Log("Game Over");
            SoundControl.instance.playGameEnd();
            SubmitScore.Score = MainControl.score;
            Invoke("moveToSubmit", 2f);
        }
    }

    void moveToSubmit()
    {
        Camera.main.GetComponent<MainControl>().showEnd();
    }
}

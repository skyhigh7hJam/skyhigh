using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private static bool first = true;
    private static int score = 0;
    bool active = true;
    GameObject hs;
    private bool isFirst = false;
    static float targetY = 1f;

    // Use this for initialization
    void Start()
    {
        score = 0;
        GameObject hs = GameObject.Find("HighscoreSave");
        if(hs != null && !false)
            hs.SetActive(false);
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
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LBorder" || other.gameObject.name == "RBorder")
        {
            Debug.Log("Game Over");
            if(hs != null)
            {
                hs.SetActive(true);
                hs.GetComponent<SubmitScore>().enableSave(score);
            }
        }
    }
}

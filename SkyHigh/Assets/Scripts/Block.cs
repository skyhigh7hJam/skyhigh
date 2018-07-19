using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Camera.main.transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y + 0.75f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LBorder" || other.gameObject.name == "RBorder")
        {
            Debug.Log("Game Over");
        }
    }
}

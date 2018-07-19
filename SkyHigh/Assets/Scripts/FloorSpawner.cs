using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{

    public GameObject floor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject block = Instantiate(floor, transform.position, transform.rotation);
        }
        //GameObject block = Instantiate(floor, transform.position, transform.rotation);
    }
}

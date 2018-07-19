using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{

    public List<GameObject> blocks;

    private void Start()
    {
        Debug.Log("Floor spawner: " + this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !MainControl.ended)
        {
            var rnd = blocks[(int)Mathf.Floor(UnityEngine.Random.value * blocks.Count)];
            GameObject block = Instantiate(rnd, transform.position, transform.rotation);
            SoundControl.instance.playDrop();
        }
        //GameObject block = Instantiate(floor, transform.position, transform.rotation);
    }
}

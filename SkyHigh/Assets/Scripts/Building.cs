using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public List<GameObject> blocks;

    public int height;

	// Use this for initialization
	void Start () {
        height = (int)Mathf.Floor(UnityEngine.Random.value * 5f) +1;
        for (int i = 0; i < height; i++)
        {
            var go = Instantiate(blocks[(int)Mathf.Floor(UnityEngine.Random.value * blocks.Count)],this.transform);
            go.transform.localPosition = new Vector3(0f, i * 1f, 0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

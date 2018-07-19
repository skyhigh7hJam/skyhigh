using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public List<GameObject> blocks;

    public int height;

    public GameObject text;

	// Use this for initialization
	void Start ()
    {
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
	}
	
    public void buildHeight(int height, string name, int score)
    {
        this.height = height;
        for (int i = 0; i < height; i++)
        {
            var go = Instantiate(blocks[(int)Mathf.Floor(UnityEngine.Random.value * blocks.Count)], this.transform);
            go.transform.localPosition = new Vector3(0f, i * 1f, 0f);
        }
        this.text.GetComponent<TextMesh>().text = name + "\n" + score;
        text.transform.localPosition = new Vector3(
            text.transform.localPosition.x,
            height+0.1f,
            text.transform.localPosition.z    
        );
        this.transform.Find("roof").localPosition = new Vector3(0f, height + 0.025f, 0f);
    }

	// Update is called once per frame
	void Update () {
        //this.text.transform.LookAt(new Vector3(Camera.main.transform.position.x, 100f, Camera.main.transform.position.z));
        
        this.text.transform.rotation = Quaternion.Euler(
            90f,
            180f/Mathf.PI*Mathf.Atan2(
                this.transform.position.x-Camera.main.transform.position.x,
                this.transform.position.z-Camera.main.transform.position.z ),
            0f
            );
    }
}

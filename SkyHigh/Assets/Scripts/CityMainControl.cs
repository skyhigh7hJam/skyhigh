using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMainControl : MonoBehaviour {

    public GameObject looktarget;
    public GameObject buildings;

	// Use this for initialization
	void Start () {
        Invoke("updateHighscore", 1f);
    }

    private void updateHighscore()
    {
        this.GetComponent<Highscore>().UpdateList();
        Invoke("updateHighscore", 20f);
    }
	
	// Update is called once per frame
	void Update () {
        
        Camera.main.transform.position = new Vector3(
            Mathf.Sin(Time.time*0.05f)*10f,
14f,
Mathf.Cos(Time.time * 0.05f) * 10f

            );
        Camera.main.transform.LookAt(looktarget.transform);

        //Update camera extents
        var bs = this.GetComponent<BuildingSpawner>();
        float max = Mathf.Max(Mathf.Max(bs.extents.size.y * 0.5f, bs.extents.size.z * 0.5f), bs.extents.size.x * 0.5f);
        Camera.main.orthographicSize += (max - Camera.main.orthographicSize)/50f;
    }
}

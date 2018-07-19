using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsControl : MonoBehaviour {
    public GameObject credits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        credits.SetActive(!credits.activeSelf);
    }

    public void Replay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Builder_henri");
    }
}

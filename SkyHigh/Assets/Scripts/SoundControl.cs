using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

    private AudioSource as1;
    private AudioSource as2;
    private AudioSource as3;

    private List<AudioSource> asPool;

    public List<AudioClip> start;
    public List<AudioClip> drop;
    public List<AudioClip> warning;
    public List<AudioClip> highscore;
    public List<AudioClip> gameEnd;

    private int poolIndex = 0;
    public static SoundControl instance;
    // Use this for initialization
    void Start () {
        asPool = new List<AudioSource>();
        as1 = this.GetComponents<AudioSource>()[0];
        as2 = this.GetComponents<AudioSource>()[1];
        as3 = this.GetComponents<AudioSource>()[2];
        
        asPool.Add(as1);
        asPool.Add(as2);
        asPool.Add(as3);

        instance = this.gameObject.GetComponent<SoundControl>();
        Invoke("playStart", 0.2f);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void playStart()
    {
        AudioSource asc = asPool[poolIndex % asPool.Count];
        AudioClip ac = start[(int)Mathf.Floor(UnityEngine.Random.value * start.Count)];
        if (ac != null)
        {
            poolIndex++;
            asc.PlayOneShot(ac);
        }
    }
    public void playWarning()
    {
        AudioSource asc = asPool[poolIndex % asPool.Count];
        AudioClip ac = warning[(int)Mathf.Floor(UnityEngine.Random.value * warning.Count)];
        if (ac != null)
        {
            poolIndex++;
            asc.PlayOneShot(ac);
        }
    }
    public void playDrop()
    {
        AudioSource asc = asPool[poolIndex % asPool.Count];
        AudioClip ac = drop[(int)Mathf.Floor(UnityEngine.Random.value * drop.Count)];
        if (ac != null)
        {
            poolIndex++;
            asc.PlayOneShot(ac);
        }
    }
    public void playHighscore()
    {
        AudioSource asc = asPool[poolIndex % asPool.Count];
        AudioClip ac =highscore[(int)Mathf.Floor(UnityEngine.Random.value * highscore.Count)];
        if (ac != null)
        {
            poolIndex++;
            asc.PlayOneShot(ac);
        }
    }
    public void playGameEnd()
    {
        AudioSource asc = asPool[poolIndex % asPool.Count];
        AudioClip ac = gameEnd[(int)Mathf.Floor(UnityEngine.Random.value * gameEnd.Count)];
        if (ac != null)
        {
            poolIndex++;
            asc.PlayOneShot(ac);
        }
    }




}

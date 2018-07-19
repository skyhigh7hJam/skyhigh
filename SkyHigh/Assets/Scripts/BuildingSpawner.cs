using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    public Bounds extents;
    
    public List<GameObject> prefabs;

    private List<Vector2> blocked;
    
    private List<Vector2> positions;

    private int positionSpawnLength = 6;
    private int buildings = 0;

    private List<string> handled;

    private Dictionary<int, List<Vector2>> positionsByLength;

	// Use this for initialization
	void Start () {
        extents = new Bounds(new Vector3(), new Vector3(4f, 4f, 4f));
        handled = new List<string>();
        blocked = new List<Vector2>();
        positions = new List<Vector2>();
        positionsByLength = new Dictionary<int, List<Vector2>>();

        for ( int i = 0; i < 30; i++)
        {
            for(int j = 0; j < 30; j++)
            {
                if(UnityEngine.Random.value < 0.9f)
                {
                    var p = new Vector2(i - 15, j - 15);
                    //Test blocking
                    var blockFound = false;
                    foreach(Vector2 block in blocked)
                    {
                        if(Mathf.Abs(p.magnitude - block.magnitude) < 0.5f)
                        {
                            blockFound = true;
                            break;
                        }
                    }
                    if (blockFound)
                        continue;
                    if(!positionsByLength.ContainsKey((int)(p.magnitude*10f)))
                    {
                        positionsByLength.Add((int)(p.magnitude*10f), new List<Vector2>());
                    }
                    positionsByLength[(int)(p.magnitude*10f)].Add(p);
                    positions.Add(p);
                }
            }
        }
        
	}
	
    private void spawnBuilding(int height, string name, int score)
    {
        int nots = 0;
        GameObject go = Instantiate(prefabs[0]);
        go.GetComponent<Building>().buildHeight(height, name, score);
        int tl = (int)Mathf.Floor((Mathf.Clamp( 7f - height,0f,7f)) / 7f * 100f);

        List<Vector2> possible = null;
        while (possible == null && tl < 400)
        {
            if (positionsByLength.ContainsKey(tl) && positionsByLength[tl].Count > 0)
            {
                possible = positionsByLength[tl];
                break;
            }
            tl++;
        }

        Vector2? position = null;
        if (possible == null || possible.Count == 0)
        {
            int rndpos = (int)Mathf.Floor(UnityEngine.Random.value * positions.Count);
            position = positions[rndpos];
            nots++;
        }
        else
        {
            int rndpos = (int)Mathf.Floor(UnityEngine.Random.value * possible.Count);
            position = possible[rndpos];
            positionsByLength[tl].Remove(position.Value);
        }
        positions.Remove(position.Value);
        go.transform.position = new Vector3(position.Value.x, 0f, position.Value.y);

        extents.size = new Vector3(
            Mathf.Max(extents.size.x, position.Value.x),
            Mathf.Max(extents.size.y, height),
            Mathf.Max(extents.size.y, position.Value.y)
        );

    }

    // Update is called once per frame
    void Update () {
		if(Camera.main.GetComponent<Highscore>().scores.scores.Count > buildings)
        {
            //Update buildings
            foreach( Score score in Camera.main.GetComponent<Highscore>().scores.scores)
            {
                if (handled.IndexOf(score._id) >= 0)
                    continue;
                handled.Add(score._id);
                spawnBuilding((int)Mathf.Floor(score.score/100f+1f), score.user, score.score);
            }
        }
	}
}

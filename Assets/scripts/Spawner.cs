using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject objectToSpawn;

	[Range (2, 100)]
	public int numToSpawn;
	public bool useWaypoints = true;
	public float minSpawnSize;
	public float maxSpawnSize;

	public KeyCode regenKey;

	private GameObject[] waypoints;
	private GameObject[] spawns;
	private BoxCollider spawnLimitsBox;
    private GameObject mobsParent;

	void Start ()
	{
        mobsParent = GameObject.Find("Mobs");
        if (!mobsParent) {
            Debug.LogError("No Mobs object found in scene");
        }
        spawnLimitsBox = GetComponent<BoxCollider> ();
		if (useWaypoints) {
			waypoints = GameObject.FindGameObjectsWithTag ("Waypoint");
		}
		SpawnStuff ();
		
	}

	void Update ()
	{
		if (Input.GetKeyDown (regenKey)) {
			SpawnStuff ();
		}
	}

	void SpawnStuff ()
	{
		if (spawns != null && spawns.Length > 0) {
			foreach (GameObject go in spawns) {
				Destroy (go);
			}
		}
		spawns = new GameObject [numToSpawn];
		for (int i = 0; i < numToSpawn; i++) {
			Vector3 pos = useWaypoints ? RandomWaypoint () : RandomPosition ();
            GameObject clone = Instantiate (objectToSpawn, pos, 
                                            Quaternion.identity, 
                                            mobsParent.transform);
			clone.transform.Rotate (Vector3.up, Random.Range (0, 360));

			float d = Random.Range (minSpawnSize, maxSpawnSize);
			clone.transform.localScale = new Vector3 (d, d, d);
			spawns [i] = clone;
		}
	}

	Vector3 RandomWaypoint ()
	{
		Vector3 offset = new Vector3 (Random.Range (-3f, 3f), Random.Range (-3f, 3f), 0);
		return waypoints [Random.Range (0, waypoints.Length)].transform.position + offset;
	}

	float r ()
	{

		return Random.Range (-1, 1);
	}

	Vector3 RandomPosition ()
	{
		return new Vector3 (
			Random.Range (spawnLimitsBox.bounds.min.x, spawnLimitsBox.bounds.max.x), 
			0, 
			Random.Range (spawnLimitsBox.bounds.min.z, spawnLimitsBox.bounds.max.z));
	}
}

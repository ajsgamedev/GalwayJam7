using UnityEngine;
using System.Collections;

public class SpawnObjects2 : MonoBehaviour
{
	public GameObject[] spawnPrefab;

	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;

	private float savedTime;
	private float secondsBetweenSpawning;
	private int randNum;


	// Use this for initialization
	void Start ()
	{
		savedTime = Time.time;
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
		{
			MakeThingToSpawn ();
			savedTime = Time.time; // store for next spawn
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
		}	
	}

	void MakeThingToSpawn ()
	{
		randNum = Random.Range (0, spawnPrefab.Length);
		GameObject clone = Instantiate (spawnPrefab [randNum], transform.position, transform.rotation) as GameObject;
	}
}
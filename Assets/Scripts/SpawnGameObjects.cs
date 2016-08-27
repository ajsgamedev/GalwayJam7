using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGameObjects : MonoBehaviour
{
	public GameObject[] spawnPrefab;

	private int randNum;

	public Transform cameraTransform; // reference to Camera position

	private float oldX = 0;
	private float newX = 0;
	private float lastSpawnX;

	private float distanceTravelled = 0;

	public float groundY = -2; // y coordinate for ground 

	public enum SpawningObjects {
		Ground = 0,
		ObstacleJump
	}

	public float minObstacleInterval = 1.0f;
	private int lastObstacleDistance = 0;

	private float groundWidth;
	private float groundHeight;
	private int initalGroundTiles = 10;

	private List<GameObject> GroundTiles;
	private int lastMovedIndex = 0;

	// Use this for initialization
	void Start ()
	{
		oldX = cameraTransform.transform.position.x;
		groundWidth = spawnPrefab [(int)SpawningObjects.Ground].GetComponent<Renderer>().bounds.size.y;
		groundHeight = spawnPrefab [(int)SpawningObjects.Ground].GetComponent<Renderer>().bounds.size.x;

		minObstacleInterval = minObstacleInterval * groundWidth; 

		GroundTiles = new List<GameObject> ();
		//spawn initial ground
		for (int i = - initalGroundTiles; i <= initalGroundTiles; i++) {
			Vector3 newPos = new Vector3 (oldX + i * groundWidth, groundY);
			GameObject ground = Instantiate (spawnPrefab [(int)SpawningObjects.Ground], newPos, transform.rotation) as GameObject;
			lastSpawnX = newPos.x;
			GroundTiles.Add (ground);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// update distance travelled
		newX = cameraTransform.transform.position.x;

		distanceTravelled += Mathf.Abs(newX - oldX);
		lastObstacleDistance += Mathf.Abs (newX - oldX);
		oldX = newX;

	
		if (distanceTravelled >= groundWidth) {
			distanceTravelled = distanceTravelled - groundWidth;

			SpawnGround ();
		} 
			
		if (lastObstacleDistance > minObstacleInterval) {
			if (Random.value < 0.8) {
				SpawnObstacle ();
			} 
			lastObstacleDistance = 0;

		}

	}

	void SpawnGround () {

		//spawn new ground
		Vector3 newPos = new Vector3 (lastSpawnX + groundWidth, groundY);
		lastSpawnX = newPos.x;
		GroundTiles [lastMovedIndex].transform.position = newPos;
		lastMovedIndex++;
		if (lastMovedIndex == GroundTiles.Count)
			lastMovedIndex = 0;
	}

	void SpawnObstacle () {
		Vector3 newPos = new Vector3 (lastSpawnX + lastObstacleDistance +  (-0.5f + Random.value) * groundWidth, groundY + groundHeight / 2);
		lastObstacleDistance = 0;
		GameObject obstacle = Instantiate (spawnPrefab [(int)SpawningObjects.ObstacleJump], newPos, transform.rotation) as GameObject;
			
	}
}
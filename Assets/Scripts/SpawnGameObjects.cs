using UnityEngine;
using System.Collections;

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
	private int initalGroundTiles = 5;

	// Use this for initialization
	void Start ()
	{
		oldX = cameraTransform.transform.position.x;
		groundWidth = spawnPrefab [(int)SpawningObjects.Ground].GetComponent<Renderer>().bounds.size.y;
		groundHeight = spawnPrefab [(int)SpawningObjects.Ground].GetComponent<Renderer>().bounds.size.x;


		//spawn initial ground
		for (int i = - initalGroundTiles; i <= initalGroundTiles; i++) {
			Vector3 newPos = new Vector3 (oldX + i * groundWidth, groundY);
			GameObject ground = Instantiate (spawnPrefab [(int)SpawningObjects.Ground], newPos, transform.rotation) as GameObject;
			lastSpawnX = newPos.x;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// update distance travelled
		newX = cameraTransform.transform.position.x;
		distanceTravelled += newX - oldX;
		oldX = newX;

		if (distanceTravelled >= groundWidth) {
			distanceTravelled = 0;
			SpawnGround ();
			lastObstacleDistance++;
		}

		Debug.Log (lastObstacleDistance);
		if (lastObstacleDistance > minObstacleInterval) {
			if (Random.value < 0.2) {
				SpawnObstacle ();
			}
		}

	}

	void SpawnGround () {

		//spawn new ground
		Vector3 newPos = new Vector3 (lastSpawnX + groundWidth, groundY);
		lastSpawnX = newPos.x;
		GameObject ground = Instantiate (spawnPrefab [(int)SpawningObjects.Ground], newPos, transform.rotation) as GameObject;
	}

	void SpawnObstacle () {
		Vector3 newPos = new Vector3 (lastSpawnX + groundWidth * Random.value, groundY + groundHeight / 2);
		lastObstacleDistance = 0;
		GameObject obstacle = Instantiate (spawnPrefab [(int)SpawningObjects.ObstacleJump], newPos, transform.rotation) as GameObject;
			
	}
}
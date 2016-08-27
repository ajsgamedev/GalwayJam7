using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	public GameObject[] spawnPrefab;

	private int randNum;

	public Transform cameraTransform; // reference to Camera position

	private float oldX = 0;
	private float newX = 0;
	private float distanceTravelled = 0;

	public float groundY = -2; // y coordinate for ground 

	public enum SpawningObjects {
		Ground = 0
	}

	private float groundWidth;

	// Use this for initialization
	void Start ()
	{
		oldX = cameraTransform.transform.position.x;
		groundWidth = spawnPrefab [(int)SpawningObjects.Ground].GetComponent<Renderer>().bounds.size.y;

		//spawn initial ground
		for (int i = - 4; i <= 4; i++) {
			Vector3 newPos = new Vector3 (oldX + i * groundWidth, groundY);
			GameObject ground = Instantiate (spawnPrefab [(int)SpawningObjects.Ground], newPos, transform.rotation) as GameObject;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// update distance travelled
		newX = cameraTransform.transform.position.x;
		distanceTravelled += newX - oldX;
		oldX = newX;

		Debug.Log ("distanceTravelled " +  distanceTravelled);

		if (distanceTravelled >= groundWidth) {
			distanceTravelled = 0;
			SpawnNewObjects ();
		}
	}

	void SpawnNewObjects () {
		Vector3 newPos = new Vector3 (cameraTransform.transform.position.x + groundWidth, groundY);
	
		//spawn new ground
		GameObject ground = Instantiate (spawnPrefab [(int)SpawningObjects.Ground], newPos, transform.rotation) as GameObject;
	}
}
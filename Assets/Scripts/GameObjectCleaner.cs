using UnityEngine;
using System.Collections;

public class GameObjectCleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag != "Floor")
			Destroy(col.gameObject);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag != "Floor")
			Destroy(col.gameObject);
	}
}

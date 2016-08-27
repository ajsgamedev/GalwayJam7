using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour {

	public int HealthReduction = -30;

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("player hit");
		if (other.tag == "Player")
		{
			ScoreManager.ChangeHealth(HealthReduction);

			//todo: trigger animation, stop movement
		}
	}
}

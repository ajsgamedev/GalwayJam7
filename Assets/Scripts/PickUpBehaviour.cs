using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpBehaviour : MonoBehaviour
{

	public int score;
	public int healthDamage;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			
			ScoreManager.score += score;
			HandlePickUp ();
			Destroy (this.gameObject);
		}
	}

	void HandlePickUp()
	{
		ScoreManager.ChangeHealth(-healthDamage);
	}
}

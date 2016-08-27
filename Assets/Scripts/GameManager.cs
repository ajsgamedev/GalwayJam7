using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	public AudioSource crowd;
	public AudioSource song;

	public GameObject GameOver;
	public GameObject ResetGame;
	public GameObject ExitGame;
	public GameObject BalloonSpawners;
	public GameObject Player;
	public GameObject endGameObjects;

	AudioSource music;

	private double finalScore;

	void Awake ()
	{
		
		GameOver.SetActive (false);
		ResetGame.SetActive (false);
		ExitGame.SetActive (false);
		endGameObjects.SetActive (false);

		BalloonSpawners.SetActive (true);
		Player.SetActive (true);
	}

	// setup the game
	void Start ()
	{
		// get a reference to the GameManager component for use by other scripts
		if (gm == null)
			gm = this.gameObject.GetComponent<GameManager> ();

	}

	// this is the main game event loop
	void Update ()
	{
		if (ScoreManager.score >= 250.0)
		{  // check to see if beat game
			finalScore = ScoreManager.score;
			EndGame ();
		}

	}

	public void EndGame ()
	{
		// game is over

		GameOver.SetActive (true);
		ResetGame.SetActive (true);
		ExitGame.SetActive (true);
		endGameObjects.SetActive (true);

		BalloonSpawners.SetActive (false);
		Player.SetActive (false);

		ScoreManager.score = finalScore;
		crowd.volume = 0.1f;
		song.volume = 0.6f;
		song.pitch = 0.8f;
	}

	public void ResetLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}


	// public function that can be called to exit the game
	public void ReturnToMainMenu ()
	{
		
		SceneManager.LoadScene ("MainMenu");

	}
		
}

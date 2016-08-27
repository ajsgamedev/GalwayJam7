using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	//public AudioSource crowd;
	//public AudioSource song;

	public GameObject GameOver;
	public GameObject ResetGame;
	public GameObject ExitGame;
	//public GameObject BlockSpawners;
	public GameObject UIPaused;
	///public GameObject endGameObjects;

	AudioSource music;

	private int finalScore;

	void Awake ()
	{
		
		GameOver.SetActive (false);
		ResetGame.SetActive (false);
		ExitGame.SetActive (false);
		//endGameObjects.SetActive (false);
		UIPaused.SetActive (false);
		//BlockSpawners.SetActive (true);
	
	}

	// setup the game
	void Start ()
	{
		Time.timeScale = 1f;
		// get a reference to the GameManager component for use by other scripts
		if (gm == null)
			gm = this.gameObject.GetComponent<GameManager> ();

	}

	// this is the main game event loop
	void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Debug.Log ("button press");
			if (Time.timeScale > 0f)
			{
				
				UIPaused.SetActive (true);
				Time.timeScale = 0f;
			}
			else
			{
				
				Time.timeScale = 1f;
				UIPaused.SetActive (false);

			}

		}

		/*if ()
		{  // check to see if beat game
			EndGame ();
		}*/

	}

	public void EndGame ()
	{
		// game is over

		GameOver.SetActive (true);
		ResetGame.SetActive (true);
		ExitGame.SetActive (true);
		//endGameObjects.SetActive (true);

		Time.timeScale = 0f;

		ScoreManager.score = finalScore;
		//crowd.volume = 0.1f;
		//song.volume = 0.6f;
		//song.pitch = 0.8f;
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

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
	public static int score;        // The player's score.

	Text text;                      // Reference to the Text component.

	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		score = 0;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		if (score < 0)
		{
			score = 0;
		}
		text.text = "Score: " + score;
	}
}
/*
 * Copyright (c) 2016, Gerwin van de Steeg
 * All rights reserved.
 *
 * This program is free software, distributed under the
 * BSD 2 Clause license, see the LICENSE file at the
 * top of the source tree for a full copy of the license.
 * 
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Collections;

namespace PaddleGame {
	/**
	 * A ScoringSystem
	 * 
	 * Here we store the state of the scores and the UI elements
	 * which display these scores.
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class ScoringSystem : MonoBehaviour {
		//! Player One's current score
		public int playerOneScore = 0;
		//! Player One's score UI element
		public Text playerOneScoreText;
		//! Player Two's current score
		public int playerTwoScore = 0;
		//! Player Two's score UI element
		public Text playerTwoScoreText;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * Ensures our UI elements exist and we configure ourself
		 * onto the GameConfiguration singleton
		 * 
		 */
		void Awake () {
			// ensure we're configured
			Assert.IsFalse (playerOneScoreText == null || playerOneScoreText.Equals (null), "Player One Score display text field not set");
			Assert.IsFalse (playerTwoScoreText == null || playerTwoScoreText.Equals (null), "Player Two Score display text field not set");
			Assert.IsFalse (GameConfiguration.singleton == null || GameConfiguration.singleton.Equals (null), "GameConfiguration object does not exist");
			// set the scoring system
			GameConfiguration.singleton.setScoringSystem (this);
		}

		/**
		 * Update the UI element containing player One's score with
		 * the current score for player One
		 */
		public void UpdatePlayerOneScoreDisplay() {
			playerOneScoreText.text = playerOneScore.ToString ();
		}

		/**
		 * Update the UI element containing player Two's score with
		 * the current score for player Two
		 */
		public void UpdatePlayerTwoScoreDisplay() {
			playerTwoScoreText.text = playerTwoScore.ToString ();
		}

		/**
		 * Update the UI elements for all players
		 */
		public void UpdateScoreDisplay()
		{
			UpdatePlayerOneScoreDisplay ();
			UpdatePlayerTwoScoreDisplay ();
		}

		/**
		 * Player One scored method, increases the player one score
		 */
		public void ScorePlayerOne() {
			Debug.Log ("Increasing player one score");
			playerOneScore++;
		}

		/**
		 * Player Two scored method, increases the player two score
		 */
		public void ScorePlayerTwo() {
			Debug.Log ("Increasing player two score");
			playerTwoScore++;
		}

		/**
		 * Reset the scoring system to zero for all players, then
		 * updates all scoring display
		 */
		public void Reset() {
			playerOneScore = 0;
			playerTwoScore = 0;
			UpdateScoreDisplay ();
		}
	}
}

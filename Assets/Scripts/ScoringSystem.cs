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
	public class ScoringSystem : IScoringSystem {

		//! player one score display instance
		private IPlayerScoreDisplay<int> playerOneDisplay;
		//! player one score tracker instance
		private IPlayerScore<int> playerOneScore;
		//! player two score display instance
		private IPlayerScoreDisplay<int> playerTwoDisplay;
		//! player two score tracker instance
		private IPlayerScore<int> playerTwoScore;


		/**
		 * Constructor
		 *
		 * @param {Text} displayOne the UI element used to display the score for Player One
		 * @param {Text} displayTwo the UI element used to display the score for Player Two
		 *
		 */
		public ScoringSystem(Text displayOne, Text displayTwo)
		{
			playerOneDisplay = new PlayerScoreDisplay(displayOne);
			playerOneScore = new PlayerScore();

			playerTwoDisplay = new PlayerScoreDisplay(displayTwo);
			playerTwoScore = new PlayerScore();
		}

		/**
		 * Update the UI element containing player One's score with
		 * the current score for player One
		 */
		public void UpdatePlayerOneScoreDisplay() {
			playerOneDisplay.UpdateDisplay(playerOneScore.score);
		}

		/**
		 * Update the UI element containing player Two's score with
		 * the current score for player Two
		 */
		public void UpdatePlayerTwoScoreDisplay() {
			playerTwoDisplay.UpdateDisplay(playerTwoScore.score);
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
			//Debug.Log ("Increasing player one score");
			playerOneScore.Score();
			UpdatePlayerOneScoreDisplay ();
		}

		/**
		 * Player Two scored method, increases the player two score
		 */
		public void ScorePlayerTwo() {
			//Debug.Log ("Increasing player two score");
			playerTwoScore.Score();
			UpdatePlayerTwoScoreDisplay ();
		}

		/**
		 * Reset the scoring system to zero for all players, then
		 * updates all scoring display
		 */
		public void Reset() {
			playerOneScore.Reset();
			playerTwoScore.Reset();
			UpdateScoreDisplay ();
		}
	}
}

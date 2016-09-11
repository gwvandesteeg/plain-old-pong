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
using System.Collections;

namespace PaddleGame {

	/**
	 * Script to load the Scoring System
	 * to be able to play the game
	 * 
	 * Based off of the concept provided at:
	 * @see {@link https://github.com/DmytroMindra/GrowingGamesGuidedByTests|GrowingGamesGuidedByTests}
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class ScoringSystemLoader : MonoBehaviour {
		//! UI element to display the score for Player One
		public Text playerOneScoreText;
		//! UI element to display the score for Player Two
		public Text playerTwoScoreText;
		//! the initialised scoringSystem object
		private IScoringSystem scoringSystem;

		/**
		 * Create a new scoring system ready for this game
		 *
		 * Start is called when the object this is attached to
		 * becomes active.
		 *
		 */
		void Start () {
			CreateScoringSystem ();
		}

		/**
		 * Instantiate a new ScoringSystem object and update
		 * the GameConfiguration with the object
		 *
		 */
		public void CreateScoringSystem()
		{
			scoringSystem = new ScoringSystem(playerOneScoreText, playerTwoScoreText);
			GameConfiguration.singleton.setScoringSystem (scoringSystem);
		}
	}
}

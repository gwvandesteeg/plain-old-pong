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
using UnityEngine.Assertions;
using System.Collections;

namespace PaddleGame {

	/**
	 * A Game configuration singleton
	 *
	 * Here we store the state for dealing with what kind of game we
	 * are going to be playing.
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class GameConfiguration : MonoBehaviour {
		/**
		 * Definition of the singleton
		 */
		public static GameConfiguration singleton = null;
		//! Whether player one is controlled by an AI or not.
		public bool playerOneAI = false;
		//! the paddle chosen for player one
		public int playerOnePaddleIndex = 0;
		//! Whether player two is controlled by an AI or not.
		public bool playerTwoAI = false;
		//! the paddle chosen for player two
		public int playerTwoPaddleIndex = 0;
		//! A list of possible paddle prefabs
		public GameObject[] paddles;
		//! A list of possible game arena prefabs
		public GameObject[] arenas;
		//! The selected arena
		public int chosenArena = 0;
		//! A list of possible balls
		public GameObject[] balls;
		//! The selected ball
		public int chosenBall = 0;
		//! the scoring system instantiated, should start off as null
		public ScoringSystem scoringSystem = null;
		//! the maximum paddle speed
		public float maxPaddleSpeed = 150f;
		/**
		 * the time period in seconds before the ball should be accelerated after contacting a paddle
		 */
		public float timeInterval = 30f;
		//! the multiplier for the speed increase
		public float accelerationFactor = 1.10f;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * This method initialises the singleton if it does not
		 * already exists, and deals with the logic to ensure it
		 * does not get destroyed on scene changes.
		 *
		 */
		void Awake () {
			// if the singleton doesn't exist, set ourselves to the
			// singleton
			if (singleton == null) {
				singleton = this;
			} else {
				// if the singleton isn't us, then destroy ourselves
				if (singleton != this) {
					Destroy (gameObject);
				} else {
					// instance specific assertions
					Assert.IsTrue(paddles.Length > 0, "No paddle prefabs loaded");
					Assert.IsTrue (arenas.Length > 0, "No arena prefabs loaded");
					Assert.IsTrue (balls.Length > 0, "No ball prefabs loaded");
				}
			}
			// ensure we don't get destroyed between Scene changes
			DontDestroyOnLoad (gameObject);
		}

		/**
		 * Setup the game for a Single Player, where player two is
		 * controlled by an AI
		 */
		public void SinglePlayerGame() {
			playerOneAI = false;
			playerTwoAI = true;
			ResetScoringSystem ();
		}

		/**
		 * Setup the game for Two Players
		 */
		public void TwoPlayerGame() {
			playerOneAI = false;
			playerTwoAI = false;
			ResetScoringSystem ();
		}

		/**
		 * Setup the game for zero human Players, where both
		 * players are controlled by an AI
		 */
		public void ZeroPlayerGame() {
			playerOneAI = true;
			playerTwoAI = true;
			ResetScoringSystem ();
		}

		/**
		 * Reset the game's scoring system by destroying the current
		 * system in place and setting it to null
		 *
		 */
		private void ResetScoringSystem () {
			if (scoringSystem == null || scoringSystem.Equals (null)) {
				// do nothing, we want it to be null
			}
			else {
				Destroy (scoringSystem);
				scoringSystem = null;
			}
		}

		/**
		 * Set the game's scoring system object
		 *
		 * @param {ScoringSystem} scoringObject
		 *
		 */
		public void setScoringSystem(ScoringSystem scoringObject) {
			Assert.IsTrue (scoringSystem == null || scoringSystem.Equals (null), "Scoring System object isn't null");
			scoringSystem = scoringObject;
		}

		/**
		 * fetch the GameObject prefab we use for our Arena
		 *
		 * @returns {GameObject} the arena prefab
		 *
		 */
		public GameObject getArena() {
			Assert.IsTrue (chosenArena < arenas.Length, "Arena index out of range");

			return arenas [chosenArena];
		}

		/**
		 * fetch the GameObject prefab we use for our ball
		 *
		 * @returns {GameObject} the ball prefab
		 *
		 */
		public GameObject getBall() {
			Assert.IsTrue (chosenBall < balls.Length, "Ball index out of range");
			return balls [chosenBall];
		}

		/**
		 * fetch the GameObject prefab we use for our player one paddle
		 *
		 * @returns {GameObject} the player one paddle prefab
		 *
		 */
		public GameObject getPlayerOnePaddle() {
			Assert.IsTrue (playerOnePaddleIndex < paddles.Length, "Player One Paddle index out of range");
			return paddles [playerOnePaddleIndex];
		}

		/**
		 * fetch the GameObject prefab we use for our player two paddle
		 *
		 * @returns {GameObject} the player two paddle prefab
		 *
		 */
		public GameObject getPlayerTwoPaddle() {
			Assert.IsTrue (playerTwoPaddleIndex < paddles.Length, "Player Two Paddle index out of range");
			return paddles [playerTwoPaddleIndex];
		}

	}
}

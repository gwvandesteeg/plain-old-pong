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
	 * The controls the actions of the scorezone behind player One, since
	 * that is where Player Two will score.
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class PlayerTwoScoreZone : MonoBehaviour {

		/**
		 * Called upon GameObject creation
		 *
		 * This asserts whether the GameConfiguration singletone exists and whether
		 * or not the ScoringSystem object has been loaded
		 *
		 */
		void Awake() {
			// assert gameconfiguration singleton
			Assert.IsFalse (GameConfiguration.singleton == null || GameConfiguration.singleton.Equals (null), "Missing GameConfiguration object");
			// assert scoring system
			Assert.IsFalse (GameConfiguration.singleton.scoringSystem == null || GameConfiguration.singleton.scoringSystem.Equals (null), "Missing ScoringSystem object");
		}
		
		/**
		 * Called when an object enters the scoring zone, where we specifically look
		 * for an object tagged as a Ball that way other objects can overlap this
		 * scoring zone as determined by the arena design and paddle placement.
		 * Once dealt with the ball object will be destroyed so that it does not
		 * continue to exist and interfere with new balls.
		 *
		 * @param {Collider} other the object that entered the scoring zone
		 *
		 */
		void OnTriggerEnter(Collider other) {
			// check it's a ball
			if (other.CompareTag ("Ball")) {
				// score
				GameConfiguration.singleton.scoringSystem.ScorePlayerTwo ();
				// update score display
				GameConfiguration.singleton.scoringSystem.UpdatePlayerTwoScoreDisplay ();
				// destroy old ball
				Destroy (other.gameObject);
			}
		}
	}
}

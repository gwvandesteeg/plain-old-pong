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
		 * Called when an object enters the scoring zone, where we specifically look
		 * for an object with a CanScore script component that way other objects
		 * can overlap this scoring zone as determined by the arena design and paddle
		 * placement.
		 * Once dealt with the object will be destroyed so that it does not
		 * continue to exist and interfere with new balls.
		 *
		 * @param {Collider} other the object that entered the scoring zone
		 *
		 */
		void OnTriggerEnter(Collider other) {
			// see if the object can score
			CanScore canScore = other.GetComponent<CanScore>();
			// check that we can score
			if (canScore == null || canScore.Equals (null)) {
			}
			else {
				// score
				canScore.ScorePlayerTwo ();
				// destroy the gameobject that scored
				Destroy (other.gameObject);
			}
		}
	}
}

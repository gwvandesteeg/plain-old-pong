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
	 * A ball collider class, which will need to be attached to all ball prefabs
	 * This detects whether or not the ball contacts a paddle, and if so and the
	 * relevant time period stored in the GameConfiguration singletons
	 * timeInterval has passed it will accellerate the ball according to
	 * the accellerationFactor configured in the GameConfiguration singleton
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class BallCollider : MonoBehaviour {
		//! timestamp to record the last speed increase
		private float lastSpeedIncrease = 0f;
		//! the ball prefabs rigidbody
		private Rigidbody rbody;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * This method sets up the rigidbody object
		 * 
		 */
		void Awake(){
			// fetch rigidbody
			rbody = GetComponent<Rigidbody> ();
			// assert its existance
			Assert.IsFalse (rbody == null || rbody.Equals (null), "No rigidbody present on the ball");

		}

		/**
		 * When we collide with another object determine if we need to accellerate the ball
		 *
		 * @param {Collision} collision the object we collided with
		 *
		 */
		void OnCollisionEnter(Collision collision) {
			// check it's a paddle
			if (collision.gameObject.CompareTag ("Paddle")) {
				//Debug.Log ("Collided with a paddle");
				float now = Time.time;
				// check time interval
				if (now - lastSpeedIncrease > GameConfiguration.singleton.timeInterval) {
					//Debug.Log ("Accelerating ball");
					lastSpeedIncrease = now;
					// accellerate ourselves
					rbody.velocity = rbody.velocity * GameConfiguration.singleton.accelerationFactor;
				}
			}
		}
	}
}

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
	 * The ball behaviour script, this class instantiates the ball object
	 * and controls the ball movement.
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class BallBehaviour : MonoBehaviour {
		//! the ball prefab to use
		private GameObject ballPrefab;
		//! the ball instance we want to work with
		private GameObject ballInstance;
		//! the rigidbody attached to the ball instance
		private Rigidbody rbody;
		//! boolean flag to indicate whether or not the ball is in play
		public bool ballInPlay = false;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * This method retrieves the ball prefab from the GameConfiguration
		 * singleton, then instantiates the ball and gets the related
		 * Rigidbody attached to the ball instance.
		 * 
		 */
		void Awake () {
			// ensure the GameConfiguration exists
			Assert.IsNotNull (GameConfiguration.singleton, "GameConfiguration object doesn't exist");
			// grab our prefab
			ballPrefab = GameConfiguration.singleton.getBall ();
			// create the ball
			CreateBall ();
		}

		/**
		 * Create a ball instance from the prefab and retrieve its Rigidbody
		 * component
		 *
		 */
		void CreateBall() {
			// ball does not start in play
			ballInPlay = false;
			// assert we have a prefab
			Assert.IsFalse (ballPrefab == null || ballPrefab.Equals (null), "No ball prefab retrieved");
			// create
			ballInstance = Instantiate (ballPrefab);
			// assert creation
			Assert.IsFalse (ballInstance == null || ballInstance.Equals (null), "No ball instance created");
			// attach to ourselves
			ballInstance.transform.SetParent (gameObject.transform, false);
			// get ball instance Rigidbody prefab
			rbody = ballInstance.GetComponent<Rigidbody> ();
			// assert prefab
			Assert.IsFalse (rbody == null || rbody.Equals (null), "No Rididbody attached to the ball instance");
		}

		/**
		 * FixedUpdate is called once per frame update
		 *
		 * If no ball exists create the ball and set the ball to not be in play
		 * If the ball is not in play, set it to be in play and add a force
		 *
		 */
		void FixedUpdate () {
			// if no ball, create
			if (ballInstance == null || ballInstance.Equals (null)) {
				// ball destroyed, need to create a new one
				CreateBall();
			}
			// if ball is not in play, set it to be in play and give it a shove
			if (!ballInPlay) {
				ballInPlay = true;
				rbody.AddForce(new Vector3(100f, 100f, 0)); //Vector3.left * 100);
			}
		}
	}
}

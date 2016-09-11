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
	 * The controls and instantiation of PlayerTwo's paddle based upon the prefab
	 * returned by the GameConfiguration singletons getPlayerTwoPaddle method
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 * @see PlayerOnePaddleControl where this code is an almost identical copy
	 *
	 */
	public class PlayerTwoPaddleControl : MonoBehaviour, IUserInput {
		//! the Input proxy
		public IUserInputProvider InputProvider { get; set;}
		//! the paddle prefab
		private GameObject paddlePrefab;
		//! the instantiated paddle object
		private GameObject playerPaddle;
		//! the material to attach to the players paddle
		public Material playerMaterial;
		//! the fireButton input name for this player
		public string fireButton;
		//! the directional control input axis name for this player
		public string upDown;
		//! the rigidbody attached to the paddle
		private Rigidbody rbody;
		//! the angle in degrees to rotate the playerOne paddle around the z axis
		private float playerOneRotationZ = 0f;
		//! the angle in degrees to rotate the playerTwo paddle around the z axis
		private float playerTwoRotationZ = 180f;

		/**
		 * Called upon GameObject creation
		 *
		 * Instantiate the paddle, rotate it as needed and add the relevant material
		 * to display it correctly
		 *
		 */
		void Awake () {
			// ensure the GameConfiguration exists
			Assert.IsFalse (GameConfiguration.singleton == null || GameConfiguration.singleton.Equals (null), "Missing GameConfiguration object");
			// grab our prefab
			paddlePrefab = GameConfiguration.singleton.getPlayerTwoPaddle ();
			CreatePaddle ();
			SetupMaterial ();
			SetupForPlayerTwo ();
			rbody = playerPaddle.GetComponent<Rigidbody> ();
			Assert.IsFalse (rbody == null || rbody.Equals (null), "No Rigidbody attached to paddle");
		}

		/**
		 * Attach the configured material to the objects MeshRenderer
		 *
		 */
		void SetupMaterial() {
			// assert paddle
			Assert.IsFalse (playerPaddle == null || playerPaddle.Equals (null), "No paddle instantiated");
			// find the mesh renderer
			MeshRenderer rend = playerPaddle.GetComponent<MeshRenderer> ();
			Assert.IsFalse (rend == null || rend.Equals (null), "No MeshRendered attached to paddle");
			Assert.IsFalse (playerMaterial == null || playerMaterial.Equals (null), "No paddle Material retrieved");
			rend.material = playerMaterial;
		}

		/**
		 * Method to rotate the paddle if around the Z axis value for PlayerOne
		 *
		 */
		void SetupForPlayerOne() {
			// rotate the paddle to align it correctly
			playerPaddle.transform.Rotate(Vector3.forward * playerOneRotationZ);
		}

		/**
		 * Method to rotate the paddle if around the Z axis value for PlayerTwo
		 *
		 */
		void SetupForPlayerTwo() {
			// rotate the paddle to align it correctly
			playerPaddle.transform.Rotate(Vector3.forward * playerTwoRotationZ);
		}

		/**
		 * Create the paddle from the configured prefab
		 *
		 */
		void CreatePaddle() {
			// assert
			Assert.IsFalse (paddlePrefab == null || paddlePrefab.Equals (null), "No paddle prefab retrieved");
			// instantiate the paddleprefab
			playerPaddle = Instantiate (paddlePrefab);
			// set transform.parent to ourselves
			playerPaddle.transform.SetParent (gameObject.transform, false);
		}

		/**
		 * Update the paddle's Y position based upon the configured axis input by
		 * updating the paddles velocity
		 *
		 */
		void Update () {
			// determine velocity
			Vector3 velocity = new Vector3 (0f, InputProvider.GetAxis (upDown) * GameConfiguration.singleton.maxPaddleSpeed, 0f);
			// set the Rigidbody velocity
			rbody.velocity = velocity;
		}
	}
}

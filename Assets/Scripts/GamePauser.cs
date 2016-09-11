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
	 * The provides a means to pause the game
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class GamePauser : MonoBehaviour, IUserInput {
		//! the Input proxy
		public IUserInputProvider InputProvider { get; set;}
		//! store the old timescale
		private float oldTimeScale;

		/**
		 * Check if the Pause key is pressed and then pause/unpause
		 * the game accordingly
		 *
		 * Update is called once per frame
		 *
		 */
		void Update () {
			// check i the input provider has been configured
			if (InputProvider != null) {
				// if the Pause key has been pressed
				if (InputProvider.GetKeyDown (KeyCode.Pause)) {
					// toggle game time scale
					if (Time.timeScale > 0f) {
						oldTimeScale = Time.timeScale;
						//Debug.Log("Pausing game, storing old time scale: " + oldTimeScale.ToString());
						Time.timeScale = 0f;
					} else {
						Time.timeScale = oldTimeScale;
						//Debug.Log("Unpausing game, restoring time scale to: " + oldTimeScale);
					}
				}
			}
		}
	}
}

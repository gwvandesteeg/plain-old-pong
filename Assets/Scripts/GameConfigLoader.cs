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
using System.Collections;

namespace PaddleGame {
	/**
	 * A Game Configuration Loader
	 * 
	 * Here we ensure that the GameConfiguration object exist.  By attaching this
	 * script to the MainCamera we will always ensure that the GameConfiguration
	 * object exists.
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 * @see: https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
	 *
	 */
	public class GameConfigLoader : MonoBehaviour {
		//! the GameConfiguration prefab
		public GameObject gameConfiguration;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * This method initialises the GameConfiguration singleton if it
		 * does not already exists.
		 * 
		 */
		void Awake () {
			// if we don't exist, instantiate
			if (GameConfiguration.singleton == null) {
				Instantiate (gameConfiguration);
			}
		}
	}
}

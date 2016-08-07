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
using UnityEngine.SceneManagement;
using System.Collections;

namespace PaddleGame {
	/**
	 * A handler for the Single Player game button
	 * 
	 * Here we configure the action to take when the Single Player Game button
	 * is clicked.  Since we cannot link button actions to singletons and have
	 * the mapping retain through scene loads, we work around the problem by
	 * adding the method every time on the Awake method.
	 * 
	 * @author	Gerwin van de Steeg
	 * @see		UnityEngine.UI
	 *
	 */
	public class SinglePlayerButtonScript : MonoBehaviour {
		/**
		 * The button we are attached to
		 */
		private Button myButton;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * This method initialises the private variable we care about,
		 * does a couple of Assertions to ensure we are configured
		 * correctly and then attaches our function to the onClick
		 * listener. Which calls the means to setup the game for
		 * Single Player mode, and switches the game to the next Scene.
		 * 
		 */
		void Awake () {
			myButton = GetComponent<Button> ();
			// cannot use IsNotNull due to the nature of Unity.Object
			// see: https://community.unity.com/t5/Scripting/Fun-with-null/m-p/1113758
			Assert.IsFalse (myButton == null || myButton.Equals(null), "Not attached to a Button");
			// assert gameconfiguration singleton
			Assert.IsFalse (GameConfiguration.singleton == null || GameConfiguration.singleton.Equals (null), "Missing GameConfiguration object");
			// remove all existing onClick listeners
			myButton.onClick.RemoveAllListeners();
			// add our own listener using a callback
			myButton.onClick.AddListener (() => {
				// could send to a game manager or our own implemented onClick method
				// attached here, but lets just call the quit method
				Debug.Log("Single Player");
				// tell the GameConfiguration to setup the game for a single player
				GameConfiguration.singleton.SinglePlayerGame();
				// Load the next Scene
				SceneManager.LoadScene("GameScreen");
			});
		}
	}

}

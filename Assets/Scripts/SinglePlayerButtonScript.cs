/*
 * Copyright (c) 2016, Gerwin van de Steeg
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 * 
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * A handler for the exit game button
 * 
 * Here we configure the action to take when the Exit game button is clicked,
 * since we cannot link button actions to singletons and have the mapping
 * retain through scene loads, we work around the problem by adding the
 * method every time on the Awake method.
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
	 * listener.
	 * 
	 */
	void Awake () {
		myButton = GetComponent<Button> ();
		// cannot use IsNotNull due to the nature of Unity.Object
		// see: https://community.unity.com/t5/Scripting/Fun-with-null/m-p/1113758
		Assert.IsFalse (myButton == null || myButton.Equals(null), "Not attached to a Button");
		// remove all existing onClick listeners
		myButton.onClick.RemoveAllListeners();
		// add our own listener using a callback
		myButton.onClick.AddListener (() => {
			// could send to a game manager or our own implemented onClick method
			// attached here, but lets just call the quit method
			Debug.Log("Single Player");

			// TODO
			GameConfiguration.singleton.SinglePlayerGame();
			// Load the next Scene
			//SceneManager.LoadScene("");
		});
	}
}


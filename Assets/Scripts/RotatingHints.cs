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
using System.Collections;

namespace PaddleGame {
	/**
	 * A rotating hints behaviour class
	 * 
	 * This takes a list of hint strings, and slowly updates a UnityEngine.UI.Text
	 * field and replaces the content prefixed with the string "Hint: ".  The
	 * replacements are done at a regular time interval as configured by the
	 * timeInterval parameter
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 * @see		UnityEngine.UI
	 *
	 */
	public class RotatingHints : MonoBehaviour {
		/**
		 * The hints to display
		 */
		public string[] hints;
		/**
		 * The time interval in seconds before changing the displayed
		 * hint to the next value.
		 */
		public float timeInterval = 5;
		/**
		 * The time the hint was last changed since the start of the
		 * GameObject creation.
		 */
		private float lastUpdate;
		/**
		 * index counter into the hints list
		 */
		private int index = 0;
		/**
		 * The UnityEngine.UI.Text object we will be manipulating
		 */
		private Text textField;

		/**
		 * Start method called upon when the GameObject this script
		 * is attached to becomes Active for the first time
		 *
		 * This method initialises the private variables we care about
		 * and does a couple of Assertions to ensure we are configured
		 * correctly.
		 * 
		 */
		void Start () {
			// initialise the last updated timestamp
			lastUpdate = Time.time;
			// get the textField we want
			textField = gameObject.GetComponent<Text> ();
			// cannot use IsNotNull due to the nature of Unity.Object
			// see: https://community.unity.com/t5/Scripting/Fun-with-null/m-p/1113758
			Assert.IsFalse (textField == null || textField.Equals(null), "No text field component");
			Assert.IsTrue (hints.Length > 0,  "No hints configured");
			Assert.IsTrue (hints.Length >= index, "Initial index too large");
		}
		
		/**
		 * Every fixed framerate frame we check whether or not we need
		 * to update the Hint being displayed.
		 * 
		 */
		void FixedUpdate () {
			float now = Time.time;
			float diff = now - lastUpdate;
			// check if we need to change the hint
			if (diff > timeInterval) {
				lastUpdate = now;
				// use modulo to ensure we stay inside the hints length
				textField.text = "Hint: " + hints [index % hints.Length].ToString ();
				// ensure we won't run out of integers
				index = (index + 1) % hints.Length;
			}
		}
	}
}

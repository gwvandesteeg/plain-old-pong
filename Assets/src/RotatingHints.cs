﻿/*
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
using System.Collections;

/**
 * A rotating hints behaviour script
 * 
 * This takes a list of hint strings, and slowly updates a UnityEngine.UI.Text
 * field and replaces the content prefixed with the string "Hint: ".  The
 * replacements are done at a regular time interval as configured by the
 * timeInterval parameter
 * 
 * @author	Gerwin van de Steeg
 * @see		UnityEngine.UI
 *
 */
public class RotatingHints : MonoBehaviour {
	public string[] hints;
	public float timeInterval = 15;
	private float lastUpdate;
	private int index = 0;
	private Text textField;

	// Use this for initialization
	void Start () {
		// initialise the last updated timestamp
		lastUpdate = Time.time;
		// get the textField we want
		textField = gameObject.GetComponent<Text> ();
		Assert.IsNotNull (textField, "No text field component");
		Assert.IsTrue (hints.Length > 0,  "No hints configured");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// disable hints if no hints exist
		if (hints.Length > 0) {
			gameObject.SetActive (true);
			float now = Time.time;
			float diff = now - lastUpdate;
			if (diff > timeInterval) {
				lastUpdate = now;
				// use modulo to ensure we stay inside the hints length
				textField.text = "Hint: " + hints [index % hints.Length].ToString ();
				index++;
			}
		} else {
			gameObject.SetActive (false);
		}
	}
}

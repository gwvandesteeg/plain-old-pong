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
	 * User Input provider Implementation for real user input
	 * 
	 * Based off of the concept provided at:
	 * @see {@link https://github.com/DmytroMindra/GrowingGamesGuidedByTests|GrowingGamesGuidedByTests}
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class RealUserInputProvider : IUserInputProvider {
		/**
		 * Wrapper around UnityEngine.Input.GetAxis
		 * 
		 * @param {string} axisName
		 * @returns {float}
		 * @see {@link UnityEngine.Input.GetAxis}
		 * 
		 */
		public float GetAxis (string axisName){
			return Input.GetAxis (axisName);
		}
		/**
		 * Wrapper around UnityEngine.Input.GetButton
		 * 
		 * @param {string} buttonName
		 * @returns {bool}
		 * @see {@link UnityEngine.Input.GetButton}
		 * 
		 */
		public bool GetButton(string buttonName) {
			return Input.GetButton (buttonName);
		}

		/**
		 * Wrapper around UnityEngine.Input.GetKeyDown
		 * 
		 * @param {string} keyName
		 * @returns {bool}
		 * @see {@link UnityEngine.Input.GetKeyDown}
		 * 
		 */
		public bool GetKeyDown(string keyName) {
			return Input.GetKeyDown (keyName);
		}

		/**
		 * Wrapper around UnityEngine.Input.GetKeyDown
		 * 
		 * @param {KeyCode} keyCode
		 * @returns {bool}
		 * @see {@link UnityEngine.Input.GetKeyDown}
		 * 
		 */
		public bool GetKeyDown(KeyCode keyCode) {
			return Input.GetKeyDown (keyCode);
		}
	}
}

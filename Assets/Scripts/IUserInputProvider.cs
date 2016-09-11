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

namespace PaddleGame {
	/**
	 * Use an interface to define the UserInput system so
	 * that we can proxy the input system using whatever
	 * input provider system we want.
	 * 
	 * Based off of the concept provided at:
	 * @see {@link https://github.com/DmytroMindra/GrowingGamesGuidedByTests|GrowingGamesGuidedByTests}
	 * 
	 * @author	Gerwin van de Steeg
	 * 
	 */
	public interface IUserInputProvider {
		/**
		 * Access the named movement Axis
		 *
		 * @param {string} axisName
		 * @returns {float}
		 * @see {@link UnityEngine.Input.GetAxis}
		 *
		 */
		float GetAxis (string axisName);
		/**
		 * Access the named button
		 *
		 * @param {string} buttonName
		 * @returns {bool}
		 * @see {@link UnityEngine.Input.GetButton}
		 *
		 */
		bool GetButton(string buttonName);
		/**
		 * Access the named key
		 *
		 * @param {string} keyName
		 * @returns {bool}
		 * @see {@link UnityEngine.Input.GetKeyDown}
		 *
		 */
		bool GetKeyDown (string keyName);
		/**
		 * Access the named key by KeyCode
		 *
		 * @param {KeyCode} keyCode
		 * @returns {bool}
		 * @see {@link UnityEngine.Input.GetKeyDown}
		 *
		 */
		bool GetKeyDown (KeyCode keyCode);
	}
}

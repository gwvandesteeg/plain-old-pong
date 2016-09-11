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
	 * https://github.com/DmytroMindra/GrowingGamesGuidedByTests
	 * 
	 * @author	Gerwin van de Steeg
	 * 
	 */
	public interface IUserInputProvider {
		//! provide a means to access the movement Axis
		float GetAxis (string axisName);
		//! provide a means toa access a configure input button
		bool GetButton(string buttonName);
		//! provide a means to access a specific key
		bool GetKeyDown (string keyName);
		bool GetKeyDown (KeyCode keyCode);
	}
}

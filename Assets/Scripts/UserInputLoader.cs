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
using System.Linq;

namespace PaddleGame {

	/**
	 * Script to load the Real User Input object
	 * to be able to play the game
	 * 
	 * Based off of the concept provided at:
	 * https://github.com/DmytroMindra/GrowingGamesGuidedByTests
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class UserInputLoader : MonoBehaviour {

		// Use this for initialization
		void Start () {
			InitializeUserInput();
		}

		void InitializeUserInput ()
		{
			IUserInputProvider input = new RealUserInputProvider ();
			var components = this.GetComponentsInChildren<MonoBehaviour> ().Where (c => c is IUserInput).Cast<IUserInput> ();
			foreach (var component in components)
				component.InputProvider = input;
		}
	}
}

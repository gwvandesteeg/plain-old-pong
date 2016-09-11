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
using System.Linq;

namespace PaddleGame {

	/**
	 * Script to load the Real User Input object
	 * to be able to play the game, needs to be
	 * attached to the root component of the game
	 * itself, or at least the root component for
	 * all other components that require UserInput.
	 * 
	 * Based off of the concept provided at:
	 * @see {@link https://github.com/DmytroMindra/GrowingGamesGuidedByTests|GrowingGamesGuidedByTests}
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class UserInputLoader : MonoBehaviour {

		/**
		 * Upon this object becoming active find all child
		 * objects which implement the IUserInput interface
		 * and set them to use the InterfaceProvider we
		 * have instantiated.
		 *
		 */
		void Start () {
			InitializeUserInput();
		}

		/**
		 * Find all child objects which implement the
		 * IUserInput interface and set them to use
		 * the InterfaceProvider we have instantiated.
		 *
		 */
		public void InitializeUserInput ()
		{
			IUserInputProvider input = new RealUserInputProvider ();
			var components = this.GetComponentsInChildren<MonoBehaviour> ().Where (c => c is IUserInput).Cast<IUserInput> ();
			foreach (var component in components) {
				component.InputProvider = input;
			}
		}
	}
}

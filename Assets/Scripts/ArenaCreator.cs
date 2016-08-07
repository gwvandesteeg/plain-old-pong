/*
 * Copyright (c) 2016, Gerwin van de Steeg
 * All rights reserved.
 *
 * This program is open source software, distributed under
 * the BSD 2 Clause license, see the LICENSE file at the
 * top of the source tree for a full copy of the license.
 * 
 */
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

namespace PaddleGame {
	/**
	 * An Arena Instantiation class
	 * 
	 * This class instantiates the Arena as specified by the
	 * prefab returned by the GameConfiguration.getArena()
	 * public method and makes the gameobject this is
	 * attached to the parent of the Arena instance.
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class ArenaCreator : MonoBehaviour {
		//! the arenaPrefab game object
		private GameObject arenaPrefab = null;
		//! the instantiated arena prefab object
		private GameObject arena;

		/**
		 * Awake method called upon when the GameObject this script
		 * is attached to is created
		 *
		 * This method creates an instance of the selected game arena
		 * 
		 */
		void Awake() {
			// ensure the GameConfiguration exists
			Assert.IsNotNull (GameConfiguration.singleton, "GameConfiguration object doesn't exist");
			// grab our prefab
			arenaPrefab = GameConfiguration.singleton.getArena ();
			Assert.IsFalse (arenaPrefab == null || arenaPrefab.Equals (null), "No arena prefab retrieved");
			CreateArena (arenaPrefab);
		}

		/**
		 * The method to create the Arena and instantiate it, then set
		 * the gameobject this script is attached to as the parent object
		 * 
		 * @param {GameObject} prefab
		 * 
		 */
		private void CreateArena(GameObject prefab) {
			// instantiate our prefab
			arena = Instantiate(prefab);
			// make it a child of ourself
			arena.transform.SetParent(gameObject.transform);
			arena.transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}
}

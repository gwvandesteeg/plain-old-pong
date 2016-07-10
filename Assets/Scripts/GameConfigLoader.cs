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
using System.Collections;

/**
 * A Game Configuration Loader
 * 
 * Here we ensure that the GameConfiguration object exist.  By attaching this
 * script to the MainCamera we will always ensure that the GameConfiguration
 * object exists.
 * 
 * @author	Gerwin van de Steeg
 *
 * @see: https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
 */

public class GameConfigLoader : MonoBehaviour {
	public GameObject gameConfiguration;

	/**
	 * Awake method called upon when the GameObject this script
	 * is attached to is created
	 *
	 * This method initialises the singleton if it does not
	 * already exists.
	 * 
	 */
	void Awake () {
		// if we don't exist, instantiate
		if (GameConfiguration.singleton == null) {
			Instantiate (gameConfiguration);
		}
	}
}

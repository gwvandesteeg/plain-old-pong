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
 * A Game configuration singleton
 * 
 * Here we store the state for dealing with what kind of game we
 * are going to be playing.
 * 
 * @author	Gerwin van de Steeg
 *
 */

public class GameConfiguration : MonoBehaviour {
	/**
	 * Definition of the singleton
	 */
	public static GameConfiguration singleton = null;
	//! Whether player one is controlled by an AI or not.
	public bool playerOneAI = false;
	//! Whether player two is controlled by an AI or not.
	public bool playerTwoAI = false;

	/**
	 * Awake method called upon when the GameObject this script
	 * is attached to is created
	 *
	 * This method initialises the singleton if it does not
	 * already exists, and deals with the logic to ensure it
	 * does not get destroyed on scene changes.
	 * 
	 */
	void Awake () {
		// if the singleton doesn't exist, set ourselves to the
		// singleton
		if (singleton == null) {
			singleton = this;
		} else {
			// if the singleton isn't us, then destroy ourselves
			if (singleton != this) {
				Destroy(gameObject);
			}
		}
		// ensure we don't get destroyed between Scene changes
		DontDestroyOnLoad (gameObject);
	}

	/**
	 * Setup the game for a Single Player, where player two is
	 * controlled by an AI
	 */
	public void SinglePlayerGame() {
		playerOneAI = false;
		playerTwoAI = true;
	}

	/**
	 * Setup the game for Two Players
	 */
	public void TwoPlayerGame() {
		playerOneAI = false;
		playerTwoAI = false;
	}

	/**
	 * Setup the game for zero human Players, where both 
	 * players are controlled by an AI
	 */
	public void ZeroPlayerGame() {
		playerOneAI = true;
		playerTwoAI = true;
	}
}

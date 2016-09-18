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
	 * Interface definition for the exposition of the ScoringSystem
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public interface IScoringSystem {
		/**
		 * Reset the scoring system
		 */
		void Reset();
		/**
		 * Increment the score for player one
		 */
		void ScorePlayerOne();
		/**
		 * Increment the score for player two
		 */
		void ScorePlayerTwo();
	}
}

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
	 * Abstraction class which exposes the scoring system on the ball object
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class CanScore : MonoBehaviour, IScoringSystem {
		//! the scoring system
		private IScoringSystem scoringSystem {get { return GameConfiguration.singleton.scoringSystem;}}

		/**
		 * Reset the scorign system, exposed only bcause of the
		 * IScoringSystem interface we're exposing
		 *
		 */
		public void Reset() {
			scoringSystem.Reset();
		}

		/**
		 * Score for player One
		 *
		 */
		public void ScorePlayerOne() {
			scoringSystem.ScorePlayerOne();
		}

		/**
		 * Score for player Two
		 *
		 */
		public void ScorePlayerTwo() {
			scoringSystem.ScorePlayerTwo();
		}
	}
}

/*
 * Copyright (c) 2016, Gerwin van de Steeg
 * All rights reserved.
 *
 * This program is free software, distributed under the
 * BSD 2 Clause license, see the LICENSE file at the
 * top of the source tree for a full copy of the license.
 *
 */
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace PaddleGame {
	/**
	 * Class to display a players score, implements
	 * the IPlayerScoreDisplay interface
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class PlayerScoreDisplay: IPlayerScoreDisplay<int>
	{
		//! the UI element used to display the score
		private Text textDisplay = null;

		/**
		 * Constructor
		 *
		 * @param {Text} textObject
		 *
		 */
		public PlayerScoreDisplay(Text textObject) {
			textDisplay = textObject;
			Assert.IsFalse(textDisplay == null || textDisplay.Equals(null), "No Text object specified");
		}

		/**
		 * Update the score display with the new score value
		 *
		 * @param {int} score
		 *
		 */
		public void UpdateDisplay(int score)
		{
			textDisplay.text = score.ToString ();
		}
	}

}

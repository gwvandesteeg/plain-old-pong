/*
 * Copyright (c) 2016, Gerwin van de Steeg
 * All rights reserved.
 *
 * This program is free software, distributed under the
 * BSD 2 Clause license, see the LICENSE file at the
 * top of the source tree for a full copy of the license.
 *
 */
namespace PaddleGame {
	/**
	 * Class to track a players score, implements
	 * the IPlayerScore interface
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class PlayerScore: IPlayerScore<int>
	{
		//! the score
		public int score { get; set; }

		/**
		 * Constructor
		 *
		 */
		public PlayerScore()
		{
			Reset();
		}

		/**
		 * Increment the Score
		 *
		 */
		public void Score()
		{
			score++;
		}

		/**
		 * Reset the score to the default value
		 *
		 */
		public void Reset()
		{
			score = 0;
		}
	}
}

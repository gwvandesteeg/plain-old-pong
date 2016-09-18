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

namespace PaddleGame {
	/**
	 * Interface to define the behaviour
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public interface IPlayerScoreDisplay<T>
	{
		/**
		 * Update the Score Display for the player
		 *
		 * @param {T} score
		 *
		 */
		void UpdateDisplay(T score);
	}

}

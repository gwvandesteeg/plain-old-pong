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
	 * Interface to define the behaviour
	 * 
	 * @author	Gerwin van de Steeg
	 *
	 */
	public interface IPlayerScore<T>
	{
		T score { get; set; }

		/**
		 * Score the player
		 */
		void Score();

		/**
		 * Reset the player's score
		 */
		void Reset();


	}
}

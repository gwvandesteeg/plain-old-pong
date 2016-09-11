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
	 * Use an interface to define the UserInput system so
	 * that we can proxy the input system using whatever
	 * input provider system we want.
	 * 
	 * Based off of the concept provided at:
	 * https://github.com/DmytroMindra/GrowingGamesGuidedByTests
	 * 
	 * @author	Gerwin van de Steeg
	 * 
	 */
	public interface IUserInput {
		//! the interface for the User Input
		IUserInputProvider InputProvider { get; set; }
	}
}
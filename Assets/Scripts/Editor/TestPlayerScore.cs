/*
 * Copyright (c) 2016, Gerwin van de Steeg
 * All rights reserved.
 *
 * This program is open source software, distributed under
 * the BSD 2 Clause license, see the LICENSE file at the
 * top of the source tree for a full copy of the license.
 * 
 */
using System.Collections;
using NUnit.Framework;

namespace PaddleGame {

	/**
	 * Unit Tests for the PlayerScore class which exposes the IPlayerScore<int>
	 * interface
	 * 
	 * @author Gerwin van de Steeg
	 * 
	 */
	public class TestPlayerScore {

		[Test]
		public void PlayerScore_Instantiate()
		{
			//Arrange
			PlayerScore obj = new PlayerScore();
			Assert.IsNotNull (obj, "Object doesn't exist");
		}

		[Test]
		public void PlayerScore_Score()
		{
			PlayerScore obj = new PlayerScore ();

			Assert.AreEqual (obj.score, 0, "Initial score doesn't start at zero");
			long old_score = obj.score;
			obj.Score ();
			Assert.AreEqual (obj.score, old_score + 1, "Did not increment by expected number");
			long sec_score = obj.score;
			obj.Score ();
			Assert.AreEqual (obj.score, old_score + 2, "Did not increment a second time by expected number");
			Assert.AreEqual (obj.score, sec_score + 1, "Did not increment correctly");
			Assert.AreNotEqual (old_score, sec_score, "Both values were the same");
		}

		[Test]
		public void PlayerScore_Reset()
		{
			PlayerScore obj = new PlayerScore ();
			Assert.AreEqual (obj.score, 0, "Initial score doesn't start at zero");
			obj.Score ();
			obj.Score ();
			obj.Score ();
			obj.Score ();
			obj.Score ();
			Assert.AreNotEqual (obj.score, 0, "Score didn't change");
			obj.Reset ();
			Assert.AreEqual (obj.score, 0, "Reset score failed");
		}
	}
}
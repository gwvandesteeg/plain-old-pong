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
using System.Collections;

namespace PaddleGame {
	/**
	 * Quick and dirty class to give the ball a shove in a
	 * specific direction used in Testing ball interaction
	 * behaviour
	 *
	 * @author	Gerwin van de Steeg
	 *
	 */
	public class BallAcceleration : MonoBehaviour {

		public float x = 0f;
		public float y = 0f;
		public float z = 0f;

		void Start () {
			Rigidbody rbody = GetComponent<Rigidbody>();
			rbody.velocity = new Vector3(x,y,z);
		}
	}
}

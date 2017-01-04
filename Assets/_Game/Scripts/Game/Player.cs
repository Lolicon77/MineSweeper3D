using UnityEngine;
using System.Collections;
using L7;

namespace Game {
	public class Player : SingletonForMonoInstantiateOnAwake<Player> {

		private bool isAlive = true;
		private bool isGrounded;
		private bool isGroundedLastFrame;

		private float minHeight = 0.05f;

		void Update() {
			if (!isAlive) {
				return;
			}
			isGrounded = transform.position.y < minHeight;
			if (isGrounded) {
				Check();
			}
		}

		private void Check() {
			if (LandmineManager.Instance.ExistLandmine(transform.position.x, transform.position.z)) {
				Debug.LogError("Die");
				isAlive = false;
			}
		}


	}
}
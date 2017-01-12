using UnityEngine;
using System.Collections;
using L7;

namespace Game {
	public class Player : SingletonForMonoInstantiateOnAwake<Player> {

		private bool isAlive = true;
		private bool isGrounded;
		private bool isGroundedLastFrame;

		private float minHeight = 0.05f;

		private float positionX;
		private float positionZ;

		void Update() {
			if (!isAlive) {
				return;
			}
			isGrounded = transform.position.y < minHeight;
			if (isGrounded) {
				CheckLandmine();
			}
		}

		void CheckLandmine() {
			if (LandmineManager.Instance.ExistLandmine(transform.position.x, transform.position.z)) {
				Debug.LogError("Die");
				isAlive = false;
			}
		}

		void CheckPosition() {
			if (transform.position.x == positionX && transform.position.z == positionZ) {

			}
		}

		void OnMoveToOtherSquare() {

		}

	}
}
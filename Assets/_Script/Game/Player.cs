using UnityEngine;
using System.Collections;
using L7;
using UI;

namespace Game {
	public class Player : SingletonForMonoInstantiateOnAwake<Player> {

		private bool isAlive = true;
		private bool isGrounded;
		private bool isGroundedLastFrame;

		private float minHeight = 0.05f;

		private int positionX;
		private int positionZ;

		void Update() {
			if (!isAlive) {
				return;
			}
			isGrounded = transform.position.y < minHeight;
			if (isGrounded) {
				CheckPosition();
			}
		}

		void CheckPosition() {
			var currentPositionX = Mathf.FloorToInt(transform.position.x);
			var currentPositionZ = Mathf.FloorToInt(transform.position.z);
			if (currentPositionX == positionX && currentPositionZ == positionZ) {
				return;
			}
			positionX = currentPositionX;
			positionZ = currentPositionZ;
			OnMoveToOtherSquare();
		}

		void OnMoveToOtherSquare() {
			CheckLandmine();
		}

		void CheckLandmine() {
			if (LandmineManager.Instance.ExistLandmine(transform.position.x, transform.position.z)) {
				isAlive = false;
				UIManager.Instance.uiMain.LinemineCountAround.text = LandmineManager.Instance.GetLandmineAroundCount().ToString();
			}
		}

		void Die() {
			Debug.LogError("Die");
			Instantiate(GameManager.Instance.boomEffect, transform.position, Quaternion.identity);
		}

	}
}
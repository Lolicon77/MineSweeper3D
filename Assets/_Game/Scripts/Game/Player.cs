using UnityEngine;
using System.Collections;

namespace Game {
	public class Player : Singleton<Player> {

		private bool isAlive;

		void Update() {
			if (transform.position.y < -5) {
				if (isAlive) {
					Die();
				}
			}
		}

		public void Die() {
			//todo
			isAlive = false;
			Debug.Log("Game Over");
		}

	}
}
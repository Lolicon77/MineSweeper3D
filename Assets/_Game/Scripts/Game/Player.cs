using UnityEngine;
using System.Collections;
using L7;

namespace Game {
	public class Player : SingletonForMonoInstantiateOnAwake<Player> {

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
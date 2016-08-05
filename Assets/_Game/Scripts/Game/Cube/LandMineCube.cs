using UnityEngine;
using System.Collections;

namespace Game {
	public class LandMineCube : MonoBehaviour {

		void OnCollisionEnter(Collision other) {
			//层检测
			if (1 << other.gameObject.layer == LayerManager.Ins.player) {
				Boom();
			}
		}

		void Boom() {
			//todo Boom Effect
			Player.Ins.Die();
		}

	}
}

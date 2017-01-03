using UnityEngine;
using System.Collections;

namespace Game {
	public class MineSweeperCube : MonoBehaviour {

		public TextMesh textMesh;

		internal int rowIndex;
		internal int lineIndex;

		internal bool haveLandMine;

		//		void Start() {
		//			//for test
		//			if (haveLandMine) {
		//				textMesh.text = "9";
		//			}
		//		}


		void OnCollisionEnter(Collision other) {
			//层检测
			if (1 << other.gameObject.layer == LayerManager.Instance.player) {
				if (haveLandMine) {
					Boom();
				} else {
					ShowNumber();
				}
			}
		}

		void Boom() {
			var boomEffect = Instantiate(GameManager.Instance.boomEffect);
			boomEffect.transform.position = transform.position;
			Player.Instance.GetComponent<Rigidbody>().AddExplosionForce(200,transform.position,10);
			Player.Instance.Die();
		}

		void ShowNumber() {
			textMesh.text = GetLineMineNumberAround().ToString("d");
		}

		int GetLineMineNumberAround() {
			int number = 0;
			for (int i = rowIndex - 1; i < rowIndex + 2; i++) {
				for (int j = lineIndex - 1; j < lineIndex + 2; j++) {
					if (GameManager.Instance.GetCube(i, j) && GameManager.Instance.GetCube(i, j).haveLandMine) {
						number++;
					}
				}
			}
			return number;
		}

	}
}
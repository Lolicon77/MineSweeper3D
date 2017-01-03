using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using L7;

namespace Game {
	public class GameManager : SingletonForMonoInstantiateOnAwake<GameManager> {

		public int row;
		public int line;
		public int landMineCount;


		public MineSweeperCube mineSweeperCube;
		public GameObject boomEffect;

		private List<MineSweeperCube> cubes;

		protected override void Awake() {
			base.Awake();
			CreateLand();
		}

		void CreateLand() {
			CreateCubes(row, line, landMineCount);
		}


		void CreateCubes(int rowNumber, int lineNumber, int landMineCount) {
			cubes = new List<MineSweeperCube>();
			for (int i = 0; i < rowNumber; i++) {
				for (int j = 0; j < lineNumber; j++) {
					var cube = Instantiate(mineSweeperCube);
					cube.rowIndex = i;
					cube.lineIndex = j;
					cube.transform.position = new Vector3(i * 1.05f, 0, j * 1.05f);
					cubes.Add(cube);
				}
			}
			RandomSetLindMine(rowNumber * lineNumber, landMineCount);
		}

		public MineSweeperCube GetCube(int rowIndex, int LineIndex) {
			if (rowIndex < 0 || rowIndex > row - 1 || LineIndex < 0 || LineIndex > line - 1) {
				return null;
			}
			return cubes[rowIndex * row + LineIndex];
		}

		void RandomSetLindMine(int max, int landMineCount) {
			var numList = new List<int>();
			for (int i = 0; i < landMineCount; i++) {
				while (true) {
					var randomNumber = Random.Range(0, max);
					if (!numList.Contains(randomNumber)) {
						cubes[randomNumber].haveLandMine = true;
						numList.Add(randomNumber);
						break;
					}
				}
			}
		}


	}
}
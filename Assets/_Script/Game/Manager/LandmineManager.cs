using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using L7;

namespace Game {
	public class LandmineManager : SingletonForMonoInstantiateOnAwake<LandmineManager> {

		public List<Landmine> currentLandmineList = new List<Landmine>();

		private Landmine currentLandmine;

		public bool ExistLandmine(float x, float z) {
			currentLandmine.row = Mathf.FloorToInt(x);
			currentLandmine.column = Mathf.FloorToInt(z);
			return currentLandmineList.Contains(currentLandmine);
		}

		public void InitLandmine(int rowCount, int columnCount, int landMineCount) {
			currentLandmineList.Clear();
			for (int i = 0; i < landMineCount; i++) {
				while (true) {
					var landmine = new Landmine {
						row = Random.Range(0, rowCount),
						column = Random.Range(0, columnCount)
					};
					if (!currentLandmineList.Contains(landmine)) {
						currentLandmineList.Add(landmine);
						break;
					}
				}
			}
		}

		public int GetLandmineAroundCount() {
			int number = 0;
			for (int i = 0; i < currentLandmineList.Count; i++) {
				var other = currentLandmineList[i];
				if (Mathf.Abs(currentLandmine.row - other.row) < 2 && Mathf.Abs(currentLandmine.column - other.column) < 2) {
					number++;
				}
			}
			return number;
		}

	}
}
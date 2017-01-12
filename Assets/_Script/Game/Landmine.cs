using UnityEngine;
using System.Collections;

namespace Game {
	public struct Landmine {
		public int row;
		public int column;

		public override string ToString() {
			return "( " + row + "," + column + ")";
		}
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI {
	public class UI_Main : MonoBehaviour, IViewer {
		public uint uiId { get; private set; }
		public string uiName { get; private set; }

		public Text LinemineCountAround;
	}
}
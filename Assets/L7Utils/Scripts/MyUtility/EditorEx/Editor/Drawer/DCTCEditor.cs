using System;
using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorHelper;

namespace L7 {

	[CustomEditor(typeof(DymaticComplieTestCode))]
	public class DCTCEditor : Editor {
		private bool state1 = false;
		private bool state2 = true;

		private string nameSpaces;
		private string testCode;

		public override void OnInspectorGUI() {
			DymaticComplieTestCode dctc = (DymaticComplieTestCode)target;

			using (new FoldableBlock(ref state1, "TestByString")) {
				if (state1) {
					nameSpaces = EditorGUILayout.TextArea(nameSpaces, GUILayout.Height(50));
					testCode = EditorGUILayout.TextArea(testCode, GUILayout.Height(200));
					if (GUILayout.Button("Test")) {
						StopWatchUtil.QuickStart(() => {
							dctc.TestCSharpCode(AppDomain.CurrentDomain.GetAssemblies()
							, nameSpaces, testCode);
						});
					}
					EditorGUILayout.HelpBox("不要使用命名空间，类名，方法名包含TestCSharpCode，DymaticComplieTestCode的代码", MessageType.Info);
				}
			}

			using (new FoldableBlock(ref state2, "TestByFile")) {
				if (state2) {
					dctc.textAsset = (TextAsset)EditorGUILayout.ObjectField("cs文本:", dctc.textAsset, typeof(TextAsset), false);
					if (GUILayout.Button("Test")) {
						StopWatchUtil.QuickStart(() => {
							dctc.TestCSharpCode(AppDomain.CurrentDomain.GetAssemblies()
						, null, dctc.textAsset.text, true);
						});
					}
					EditorGUILayout.HelpBox("不要使用命名空间，类名，方法名包含TestCSharpCode，DymaticComplieTestCode的代码", MessageType.Info);
				}
			}
		}
	}
}
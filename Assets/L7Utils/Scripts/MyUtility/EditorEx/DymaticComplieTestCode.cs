//#if UNITY_EDITOR && UNITY_STANDALONE_WIN
//using System;
//using System.CodeDom.Compiler;
//using System.Reflection;
//using System.Text;
//using Microsoft.CSharp;
//using UnityEngine;
//
//namespace L7 {
//	public class DymaticComplieTestCode : MonoBehaviour {
//
//		public TextAsset textAsset;
//
//		private StringBuilder sb = new StringBuilder();
//
//		public void TestCSharpCode(string nameSpaces, string testCode, bool fromFile = false) {
//			//1>实例化C#代码服务提供对象
//			CSharpCodeProvider provider = new CSharpCodeProvider();
//			//2>声明编译器参数
//			CompilerParameters parameters = new CompilerParameters {
//				GenerateExecutable = false,
//				GenerateInMemory = true,
//			};
//			var dlls = AppDomain.CurrentDomain.GetAssemblies();
//			foreach (var assembly in dlls) {
//				parameters.ReferencedAssemblies.Add(assembly.Location);
//			}
//			try {
//				//3>动态编译
//				CompilerResults result = provider.CompileAssemblyFromSource(parameters, fromFile ? testCode : BuildCSharpCode(nameSpaces, testCode));
//				if (result.Errors.Count > 0) {
//					L7Debug.LogError("编译出错！");
//				}
//				//4>如果编译没有出错，此刻已经生成动态程序集
//				//5>开始玩C#映射
//				Assembly assembly = result.CompiledAssembly;
//				//				object obj = assembly.CreateInstance("TestCSCode.TestScript");
//				Type type = assembly.GetType("L7.TestCSCode");
//				//6>获取对象方法
//				MethodInfo method = type.GetMethod("TestCSharpCode");
//				method.Invoke(null, null);
//				//				object[] objParameters = new object[2] { 1, 5 };
//				//				int iResult = Convert.ToInt32(method.Invoke(obj, objParameters));//唤醒对象，执行行为
//			} catch (ArgumentException ex) {
//				L7Debug.LogError(ex.Message);
//			} catch (Exception ex) {
//				L7Debug.LogError(ex.Message);
//			}
//		}
//
//		private string BuildCSharpCode(string nameSpace, string testCode) {
//			sb.Length = 0;
//			sb.AppendLine(@"
//using System; 
//using UnityEngine; "
//
//+ nameSpace + @"
//
//namespace L7  
//{  
//    class TestCSCode  
//    {  
//        public static void TestCSharpCode()
//        {");
//			sb.AppendLine(testCode);
//			sb.Append(@"
//        }  
//    }  
//}  
//");
//			return sb.ToString();
//		}
//
//	}
//}
//
//
//#endif
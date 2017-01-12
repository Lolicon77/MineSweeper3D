using UnityEngine;
using System.Collections;

namespace Test {
	public class TestOutline : MonoBehaviour {
		public Material material;

		void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture) {
			//着色器实例不为空，就进行参数设置
			//设置Shader中的外部变量
			//			material.SetFloat("_IterationNumber", );
			//			material.SetFloat("_Value", Intensity);
			//			material.SetFloat("_Value2", OffsetX);
			//			material.SetFloat("_Value3", OffsetY);
			//			material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0.0f, 0.0f));

			//拷贝源纹理到目标渲染纹理，加上我们的材质效果
			Graphics.Blit(sourceTexture, destTexture, material);
		}
	}
}
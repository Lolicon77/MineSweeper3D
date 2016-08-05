using UnityEngine;
using System.Collections;

namespace Game
{
	public class Player : Singleton<Player>
	{

		public void Die() {
			//todo
			Debug.Log("Game Over");
		}
		
		 
	}
}
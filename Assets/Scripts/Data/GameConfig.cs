using UnityEngine;

namespace Data
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "Data/GameConfig", order = 0)]
	public class GameConfig : ScriptableObject
	{
		[Header( "Hero" )] 
		public float HeroSpeed;

		[Header( "Background" )] 
		public float BackgroundScrollSpeed;
	}
}
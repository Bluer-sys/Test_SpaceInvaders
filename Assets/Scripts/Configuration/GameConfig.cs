using UnityEngine;

namespace Configuration
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
	public class GameConfig : ScriptableObject
	{
		[Header( "Hero" )] 
		public float HeroSpeed;
		public int HeroBulletDamage;
		public float HeroBulletSpeed;
		public float HeroShootInterval;

		[Header( "Background" )] 
		public float BackgroundScrollSpeed;

	}
}
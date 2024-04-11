using UnityEngine;

namespace Configuration
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
	public class GameConfig : ScriptableObject
	{
		[Header( "Hero" )] 
		public float HeroSpeed;

		[Header( "Enemy" )]
		[Tooltip("Random between two values")]
		public Vector2 EnemySpawnInterval;
		public Vector2 EnemySpeed;
		public Vector2Int EnemyHealth;
		
		[Header( "Background" )] 
		public float BackgroundScrollSpeed;
	}
}
using UnityEngine;

namespace Configuration
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
	public class GameConfig : ScriptableObject
	{
		[Header( "Hero" )] 
		public float HeroSpeed;
		public int HeroHealth;

		[Header( "Enemy" )]
		[Tooltip("Random between two values")]
		public Vector2 EnemySpeed;
		public Vector2Int EnemyHealth;
		public Vector2Int EnemyReward;
		public float EnemySpawnInterval;
		
		[Header("Gameplay")] 
		public float NextWaveDifficultyAddon;
		[Tooltip("x - row, y - column")]
		public Vector2Int StartEnemyGrid;
		
		[Header( "Background" )] 
		public float BackgroundScrollSpeed;
	}
}
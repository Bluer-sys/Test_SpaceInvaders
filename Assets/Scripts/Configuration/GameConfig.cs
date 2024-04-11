﻿using UnityEngine;

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
		public Vector2 EnemySpawnInterval;
		public Vector2 EnemySpeed;
		public Vector2Int EnemyHealth;
		public Vector2Int EnemyReward;
		
		[Header( "Background" )] 
		public float BackgroundScrollSpeed;
	}
}
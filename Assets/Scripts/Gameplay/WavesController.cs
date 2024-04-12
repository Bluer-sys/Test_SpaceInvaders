using System;
using Configuration;
using Enemy.Interfaces;
using JetBrains.Annotations;
using UniRx;

namespace Gameplay
{
	[UsedImplicitly]
	public class WavesController : IDisposable
	{
		private readonly IEnemySpawner _enemySpawner;
		private readonly GameConfig _gameConfig;
		
		private int _currentWave;
		
		private readonly CompositeDisposable _lifetimeDisposables = new();

		public WavesController(IEnemySpawner enemySpawner, GameConfig gameConfig)
		{
			_enemySpawner = enemySpawner;
			_gameConfig = gameConfig;

			Observable
				.Timer( TimeSpan.FromSeconds( _gameConfig.EnemySpawnInterval ) )
				.Subscribe( _ => SetNewWave() )
				.AddTo( _lifetimeDisposables );
			
			_enemySpawner.OnEnemyDead
				.Where( _ => _enemySpawner.SpawnedEnemies.Count == 0 )
				.Delay( TimeSpan.FromSeconds( _gameConfig.EnemySpawnInterval ) )
				.Subscribe( _ => SetNewWave() )
				.AddTo( _lifetimeDisposables );
		}

		private void SetNewWave()
		{
			_enemySpawner.SpawnGrid(
				_gameConfig.StartEnemyGrid.x,
				_gameConfig.StartEnemyGrid.y,
				1 + _currentWave * _gameConfig.NextWaveDifficultyAddon 
			);
			
			_currentWave++;
		}

		public void Dispose()
		{
			_lifetimeDisposables.Dispose();
		}
	}
}
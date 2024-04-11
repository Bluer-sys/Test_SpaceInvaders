using System;
using System.Collections.Generic;
using Configuration;
using Enemy.Factory;
using Enemy.Interfaces;
using Extensions;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Utilities;
using Zenject;
using Object = UnityEngine.Object;

namespace Enemy
{
	[UsedImplicitly]
	public class EnemySpawner : IEnemySpawner, ITickable, IDisposable
	{
		private const float TopOffset = 0.5f;
		private const float LeftOffset = 0.5f;
		private const float RightOffset = -0.5f;
		
		private readonly EnemyFactory _enemyFactory;
		private readonly GameConfig _gameConfig;

		private float _spawnInterval;
		
		private readonly List<IEnemyFacade> _spawnedEnemies = new();
		private readonly CompositeDisposable _lifetimeDisposable = new();
		
		public IReadOnlyList<IEnemyFacade> SpawnedEnemies => _spawnedEnemies;
		
		public ReactiveCommand<IEnemyFacade> OnEnemyDead { get; } = new();

		public EnemySpawner( EnemyFactory enemyFactory, GameConfig gameConfig)
		{
			_enemyFactory = enemyFactory;
			_gameConfig = gameConfig;

			SetRandomInterval();
		}

		public void Tick()
		{
			Debug.Log( SpawnedEnemies.Count );
			
			_spawnInterval -= Time.deltaTime;
			
			if (_spawnInterval > 0)
			{
				return;
			}
			
			SetRandomInterval();
			Spawn();
		}

		private void Spawn()
		{
			EnemyModel enemyModel = CreateEnemyModel();

			EnemyFacade enemy = _enemyFactory.Create( enemyModel );

			_spawnedEnemies.Add( enemy );

			enemy.IsDead
				.Where( v => v )
				.First()
				.Subscribe( _ => Despawn( enemy ) )
				.AddTo( _lifetimeDisposable );
		}

		private void Despawn(EnemyFacade enemy)
		{
			_spawnedEnemies.Remove( enemy );
			Object.Destroy( enemy.gameObject );

			OnEnemyDead.Execute( enemy );
		}

		private EnemyModel CreateEnemyModel()
		{
			float randomX = UnityEngine.Random.Range(
				ScreenWorld.Left + LeftOffset, 
				ScreenWorld.Right + RightOffset
			);
			
			float y = ScreenWorld.Top + TopOffset;
			
			Vector2 randomPosition = new Vector2( randomX, y );
			
			return new EnemyModel
			{
				StartPosition = randomPosition,
				Speed = _gameConfig.EnemySpeed.Random(),
				Health = _gameConfig.EnemyHealth.Random(),
				Reward = _gameConfig.EnemyReward.Random()
			};
		}

		private void SetRandomInterval()
		{
			_spawnInterval = _gameConfig.EnemySpawnInterval.Random();
		}

		public void Dispose()
		{
			_lifetimeDisposable.Dispose();
		}
	}
}
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
using Object = UnityEngine.Object;

namespace Enemy
{
	[UsedImplicitly]
	public class EnemySpawner : IEnemySpawner, IDisposable
	{
		private const float TopOffset = -1f;
		private const float VerticalStretch = 7f;
		private const float HorizontalStretch = 1f;

		private readonly EnemyFactory _enemyFactory;
		private readonly GameConfig _gameConfig;

		private float _difficultyMultiplier = 1.0f;

		private readonly List<IEnemyFacade> _spawnedEnemies = new();
		private readonly CompositeDisposable _lifetimeDisposable = new();

		public IReadOnlyList<IEnemyFacade> SpawnedEnemies => _spawnedEnemies;
		
		public ReactiveCommand<IEnemyFacade> OnEnemyDead { get; } = new();

		public EnemySpawner( EnemyFactory enemyFactory, GameConfig gameConfig)
		{
			_enemyFactory = enemyFactory;
			_gameConfig = gameConfig;
		}

		public void SpawnGrid(int row, int column, float difficultyMultiplier = 1.0f)
		{
			_difficultyMultiplier = difficultyMultiplier;

			float horizontalStep = (ScreenWorld.Width - 2 * HorizontalStretch) / (column - 1);
			float verticalStep = (ScreenWorld.Height - VerticalStretch) / (row - 1);
			
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					Vector2 pos = new Vector2
					{
						x = ScreenWorld.Left + HorizontalStretch + horizontalStep * j,
						y = ScreenWorld.Bottom + VerticalStretch + verticalStep * i + TopOffset
					};
                    
					Spawn( pos );
				}
			}
		}

		private void Spawn(Vector2 position)
		{
			EnemyModel enemyModel = CreateEnemyModel();

			EnemyFacade enemy = _enemyFactory.Create( enemyModel );

			enemy.transform.position = position;
			
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
			return new EnemyModel
			{
				Speed = _gameConfig.EnemySpeed.Random(),
				Health = (int) (_gameConfig.EnemyHealth.Random() * _difficultyMultiplier),
				Reward = (int) (_gameConfig.EnemyReward.Random() * _difficultyMultiplier)
			};
		}

		public void Dispose()
		{
			_lifetimeDisposable.Dispose();
		}
	}
}
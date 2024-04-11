using System;
using Bullet;
using Enemy;
using Enemy.Interfaces;
using JetBrains.Annotations;
using UniRx;
using Utilities;

[UsedImplicitly]
public class ObjectsLifetimeController : IDisposable
{
	private const float DespawnInterval = 1f; 
		
	private readonly BulletPool _bulletPool;
	private readonly IEnemySpawner _enemySpawner;
	private readonly CompositeDisposable _lifetimeDisposable = new();

	private float _despawnTimer;

	public ObjectsLifetimeController(BulletPool bulletPool, IEnemySpawner enemySpawner)
	{
		_bulletPool = bulletPool;
		_enemySpawner = enemySpawner;
			
		Observable.Interval( TimeSpan.FromSeconds( DespawnInterval ) )
			.Subscribe( _ => Despawn() )
			.AddTo( _lifetimeDisposable );
	}

	private void Despawn()
	{
		for (int i = 0; i < _bulletPool.SpawnedBullets.Count; i++)
		{
			Bullet.Bullet bullet = _bulletPool.SpawnedBullets[i];

			if ( bullet.transform.position.y > ScreenWorld.Top ||
			     bullet.transform.position.y < ScreenWorld.Bottom )
			{
				_bulletPool.Despawn( bullet );
				i--;
			}
		}

		for (int i = 0; i < _enemySpawner.SpawnedEnemies.Count; i++)
		{
			IEnemyFacade enemy = _enemySpawner.SpawnedEnemies[i];
			
			if ( enemy.Transform.position.y < ScreenWorld.Bottom )
			{
				enemy.Kill();
				i--;
			}
		}
	}

	public void Dispose()
	{
		_lifetimeDisposable.Dispose();
	}
}
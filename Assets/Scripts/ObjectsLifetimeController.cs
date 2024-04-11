using System;
using Bullet;
using JetBrains.Annotations;
using UniRx;
using Utilities;

[UsedImplicitly]
public class ObjectsLifetimeController : IDisposable
{
	private const float DespawnInterval = 1f; 
		
	private readonly BulletPool _bulletPool;
	private readonly CompositeDisposable _lifetimeDisposable = new();

	private float _despawnTimer;

	public ObjectsLifetimeController(BulletPool bulletPool)
	{
		_bulletPool = bulletPool;
			
		Observable.Interval( TimeSpan.FromSeconds( DespawnInterval ) )
			.Subscribe( _ => Despawn() )
			.AddTo( _lifetimeDisposable );
	}

	public void Dispose()
	{
		_lifetimeDisposable.Dispose();
	}

	private void Despawn()
	{
		for (int i = 0; i < _bulletPool.SpawnedBullets.Count; i++)
		{
			Bullet.Bullet bullet = _bulletPool.SpawnedBullets[i];

			if ( bullet.transform.position.y < ScreenBorder.Top &&
			     bullet.transform.position.y > ScreenBorder.Bottom ) 
				continue;
				
			_bulletPool.Despawn( bullet );
			i--;
		}
	}
}
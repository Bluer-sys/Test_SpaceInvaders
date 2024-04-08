using Bullet.Base;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroGun : ITickable
	{
		private const float ShootInterval = 0.5f;
		
		private BulletPool _bulletPool;
		private IHeroFacade _heroFacade;

		private float _shootTimer;

		[Inject]
		private void Construct(BulletPool bulletPool, IHeroFacade heroFacade)
		{
			_bulletPool = bulletPool;
			_heroFacade = heroFacade;
		}

		public void Tick()
		{
			_shootTimer -= Time.deltaTime;
			
			if (_shootTimer < 0)
			{
				Shoot();
				_shootTimer = ShootInterval;
			}
		}

		private void Shoot()
		{
			BulletSettings settings = new BulletSettings
			{
				Type = BulletType.Hero,
				Damage = 1,
				Speed = 3,
				StartDirection = _heroFacade.Transform.up,
				StartPosition = _heroFacade.Transform.position
			};
			
			_bulletPool.Spawn( settings );
		}
	}
}
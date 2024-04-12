using System.Collections.Generic;
using Bullet;
using Configuration;
using Extensions;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Weapon.Base
{
	[UsedImplicitly]
	public abstract class WeaponBase : MonoBehaviour
	{
		private List<Muzzle> _muzzles;
		private BulletPool _bulletPool;
		
		protected WeaponConfig _weaponConfig;
		
		private float _shootTimer;
		
		[Inject]
		private void Construct(List<Muzzle> muzzles, BulletPool bulletPool, WeaponConfig weaponConfig)
		{
			_bulletPool = bulletPool;
			_muzzles = muzzles;
			_weaponConfig = weaponConfig;
			
			SetRandomInterval();
		}

		private void Update()
		{
			_shootTimer -= Time.deltaTime;
			
			if (_shootTimer <= 0)
			{
				Shoot();
				SetRandomInterval();
			}
		}

		protected abstract BulletModel CreateBulletModel(Muzzle muzzle);

		private void Shoot()
		{
			for (int i = 0; i < _muzzles.Count; i++)
			{
				BulletModel model = CreateBulletModel( _muzzles[i] );

				_bulletPool.Spawn( model );
			}
		}

		private void SetRandomInterval()
		{
			_shootTimer = _weaponConfig.ShootInterval.Random();
		}
	}
}
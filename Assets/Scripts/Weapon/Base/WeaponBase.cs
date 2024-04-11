using System.Collections.Generic;
using Bullet;
using Configuration;
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
		}

		public void Update()
		{
			_shootTimer -= Time.deltaTime;

			if ( _shootTimer > 0 ) 
				return;
			
			Shoot();
			_shootTimer = _weaponConfig.ShootInterval;
		}

		protected abstract BulletModel CreateBulletModel(Muzzle muzzle);

		private void Shoot()
		{
			foreach (Muzzle muzzle in _muzzles)
			{
				BulletModel model = CreateBulletModel( muzzle );
			
				_bulletPool.Spawn( model );
			}
		}
	}
}
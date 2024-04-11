﻿using System;
using System.Collections.Generic;
using Bullet;
using Configuration;
using JetBrains.Annotations;
using UniRx;
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

		[Inject]
		private void Construct(List<Muzzle> muzzles, BulletPool bulletPool, WeaponConfig weaponConfig)
		{
			_bulletPool = bulletPool;
			_muzzles = muzzles;
			_weaponConfig = weaponConfig;

			Observable
				.Interval( TimeSpan.FromSeconds( _weaponConfig.ShootInterval ) )
				.Subscribe( _ => Shoot() )
				.AddTo( this );
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
	}
}
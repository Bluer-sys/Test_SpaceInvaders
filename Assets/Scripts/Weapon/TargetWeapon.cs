using Bullet;
using Hero;
using Hero.Interfaces;
using UnityEngine;
using Weapon.Base;
using Zenject;

namespace Weapon
{
	public class TargetWeapon : WeaponBase
	{
		private IHeroFacade _heroFacade;

		[Inject]
		private void Construct(IHeroFacade heroFacade)
		{
			_heroFacade = heroFacade;
		}

		protected override BulletModel CreateBulletModel(Muzzle muzzle)
		{
			Vector3 dirToHero = _heroFacade.IsDead.Value 
				? muzzle.Up 
				: (_heroFacade.Transform.position - muzzle.Position).normalized;
			
			return new BulletModel
			{
				Sprite = _weaponConfig.BulletSprite,
				Type = _weaponConfig.Type,
				Damage = _weaponConfig.Damage,
				Speed = _weaponConfig.Speed,
				StartDirection = dirToHero,
				StartPosition = muzzle.Position
			};
		}
	}
}
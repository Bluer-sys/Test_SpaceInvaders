using Bullet;
using Weapon.Base;

namespace Weapon
{
	public class SimpleWeapon : WeaponBase
	{
		protected override BulletModel CreateBulletModel(Muzzle muzzle)
		{
			return new BulletModel
			{
				Sprite = _weaponConfig.BulletSprite,
				Type = _weaponConfig.Type,
				Damage = _weaponConfig.Damage,
				Speed = _weaponConfig.Speed,
				StartDirection = muzzle.Up,
				StartPosition = muzzle.Position
			};
		}
	}
}
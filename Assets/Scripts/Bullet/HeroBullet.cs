using Bullet.Base;
using UnityEngine;

namespace Bullet
{
	public class HeroBullet : BulletBase
	{
		protected override void Move()
		{
			_rigidbody2D.velocity = Vector2.up * _bulletSettings.Speed;
		}
	}
}
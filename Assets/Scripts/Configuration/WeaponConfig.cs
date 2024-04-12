using Bullet;
using UnityEngine;

namespace Configuration
{
	[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/WeaponConfig")]
	public class WeaponConfig : ScriptableObject
	{
		public Sprite BulletSprite;
		public BulletType Type;
		public int Damage;
		public Vector2 ShootInterval;
		public float Speed;
	}
}
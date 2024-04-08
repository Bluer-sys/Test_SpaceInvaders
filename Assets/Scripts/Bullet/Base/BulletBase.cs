using Enemy;
using Hero;
using UnityEngine;

namespace Bullet.Base
{
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class BulletBase : MonoBehaviour
	{
		protected BulletSettings _bulletSettings;
		protected Rigidbody2D _rigidbody2D;
		
		private void Awake()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}
		
		public void Initialize(BulletSettings settings)
		{
			_bulletSettings = settings;
			
			InitializeTransform();
			Move();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			switch (_bulletSettings.Type)
			{
				case BulletType.Hero:
					TryTakeDamage<EnemyFacade>( other );
					break;
				
				case BulletType.Enemy:
					TryTakeDamage<HeroFacade>( other );
					break;
			}
		}

		protected abstract void Move();

		private void InitializeTransform()
		{
			transform.position = _bulletSettings.StartPosition;
			transform.up = _bulletSettings.StartDirection;
		}

		private void TryTakeDamage<T>(Component other) where T : IDamagable
		{
			if ( other.TryGetComponent( out T damagable ) )
			{
				damagable.TakeDamage( _bulletSettings.Damage );
			}
		}
	}
}
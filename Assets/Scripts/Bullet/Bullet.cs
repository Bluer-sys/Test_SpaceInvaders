using Enemy;
using Hero;
using UniRx;
using Unit.Interfaces;
using UnityEngine;
using Utilities;
using Zenject;

namespace Bullet
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] 
		private SpriteRenderer _spriteRenderer;
		
		private Rigidbody2D _rigidbody2D;
		private Transform _transform;
		private BulletPool _bulletPool;

		private readonly CompositeDisposable _lifetimeDisposables = new();
		
		private BulletModel _bulletModel;

		[Inject]
		private void Construct(Rigidbody2D rb, Transform tr, TriggerObserver triggerObserver, BulletPool bulletPool)
		{
			_rigidbody2D = rb;
			_transform = tr;
			_bulletPool = bulletPool;
			
			triggerObserver.OnTriggerEnter
				.Subscribe( OnTriggered )
				.AddTo( _lifetimeDisposables );
		}
		
		public void Initialize(BulletModel model)
		{
			_bulletModel = model;

			_transform.position = _bulletModel.StartPosition;
			_transform.up = _bulletModel.StartDirection;
			
			_spriteRenderer.sprite = _bulletModel.Sprite;
			
			Move();
		}

		private void Move()
		{
			_rigidbody2D.velocity = transform.up * _bulletModel.Speed;
		}

		private void OnTriggered(Collider2D other)
		{
			switch (_bulletModel.Type)
			{
				case BulletType.Hero:
					TryTakeDamage<EnemyFacade>( other );
					break;
				
				case BulletType.Enemy:
					TryTakeDamage<HeroFacade>( other );
					break;
			}
		}

		private void TryTakeDamage<T>(Component other) where T : IDamagable
		{
			if ( !other.TryGetComponent( out T damagable ) ) 
				return;
			
			damagable.TakeDamage( _bulletModel.Damage );
			_bulletPool.Despawn( this );
		}

		public void OnDestroy()
		{
			_lifetimeDisposables.Dispose();
		}
	}
}
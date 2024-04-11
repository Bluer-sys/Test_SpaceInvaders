using Enemy.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyFacade : MonoBehaviour, IEnemyFacade
	{
		private IEnemyHealth _enemyHealth;
		private IEnemyMovement _enemyMovement;

		[Inject]
		private void Construct(IEnemyHealth enemyHealth, IEnemyMovement enemyMovement)
		{
			_enemyHealth = enemyHealth;
			_enemyMovement = enemyMovement;
		}

		public Transform Transform => transform;
		
		public BoolReactiveProperty IsDead => _enemyHealth.IsDead;

		public void Initialize(EnemyModel model)
		{
			transform.position = model.StartPosition;
			
			_enemyMovement.SetSpeed( model.Speed );
			_enemyHealth.Initialize( model.Health );
		}

		public void TakeDamage(int damage)
		{
			_enemyHealth.TakeDamage(damage);
		}

		public void Kill()
		{
			_enemyHealth.Kill();
		}
	}
}
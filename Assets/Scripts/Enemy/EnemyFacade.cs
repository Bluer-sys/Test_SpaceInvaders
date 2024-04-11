using Enemy.Interfaces;
using UniRx;
using Unit.Interfaces;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyFacade : MonoBehaviour, IEnemyFacade
	{
		private IUnitHealth _unitHealth;
		private IEnemyMovement _enemyMovement;

		[Inject]
		private void Construct(IUnitHealth unitHealth, IEnemyMovement enemyMovement)
		{
			_unitHealth = unitHealth;
			_enemyMovement = enemyMovement;
		}

		public Transform Transform => transform;
		
		public BoolReactiveProperty IsDead => _unitHealth.IsDead;
		
		public int Reward { get; private set; }

		public void Initialize(EnemyModel model)
		{
			transform.position = model.StartPosition;
			
			Reward = model.Reward;
			
			_enemyMovement.SetSpeed( model.Speed );
			_unitHealth.Initialize( model.Health );
		}

		public void TakeDamage(int damage)
		{
			_unitHealth.TakeDamage(damage);
		}

		public void Kill()
		{
			_unitHealth.Kill();
		}
	}
}
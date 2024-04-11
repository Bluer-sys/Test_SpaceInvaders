using UniRx;
using UnityEngine;

namespace Enemy.Interfaces
{
	public interface IEnemyFacade : IDamagable
	{
		Transform Transform { get; }
		BoolReactiveProperty IsDead { get; }
		
		void Initialize(EnemyModel model);
	}
}
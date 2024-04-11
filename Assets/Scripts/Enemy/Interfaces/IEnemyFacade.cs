using UniRx;
using Unit.Interfaces;
using UnityEngine;

namespace Enemy.Interfaces
{
	public interface IEnemyFacade : IDamagable
	{
		Transform Transform { get; }
		BoolReactiveProperty IsDead { get; }
		int Reward { get; }

		void Initialize(EnemyModel model);
		void Kill();
	}
}
using UniRx;
using Unit.Interfaces;
using UnityEngine;

namespace Hero.Interfaces
{
	public interface IHeroFacade : IDamagable
	{
		Transform Transform { get; }
		Transform Muzzle { get; }
		int MaxHealth { get; }
		IntReactiveProperty Health { get; }
		BoolReactiveProperty IsDead { get; }
		IntReactiveProperty Score { get; }
	}
}
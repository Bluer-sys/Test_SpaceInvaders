using JetBrains.Annotations;
using UniRx;
using Unit.Interfaces;
using UnityEngine;

namespace Unit
{
	[UsedImplicitly]
	public class UnitHealth : IUnitHealth
	{
		public int MaxHealth { get; private set; }
		public IntReactiveProperty Health { get; } = new();
		public BoolReactiveProperty IsDead { get; } = new();
		
		public void Initialize(int health)
		{
			MaxHealth = health;
			
			Health.Value = health;
			IsDead.Value = false;
		}

		public void TakeDamage(int damage)
		{
			Health.Value = Mathf.Clamp( Health.Value - damage, 0, MaxHealth );
			
			if (Health.Value == 0)
			{
				IsDead.Value = true;
			}
		}

		public void Kill()
		{
			Health.Value = 0;
			IsDead.Value = true;
		}
	}
}
using Enemy.Interfaces;
using JetBrains.Annotations;
using UniRx;

namespace Enemy
{
	[UsedImplicitly]
	public class EnemyHealth : IEnemyHealth
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
			Health.Value -= damage;
			
			if (Health.Value <= 0)
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
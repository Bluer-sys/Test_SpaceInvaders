using UniRx;

namespace Enemy.Interfaces
{
	public interface IEnemyHealth
	{
		int MaxHealth { get; }
		IntReactiveProperty Health { get; }
		BoolReactiveProperty IsDead { get; }

		void Initialize(int health);
		void TakeDamage(int damage);
		void Kill();
	}
}
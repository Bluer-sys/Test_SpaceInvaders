using UniRx;

namespace Unit.Interfaces
{
	public interface IUnitHealth
	{
		int MaxHealth { get; }
		IntReactiveProperty Health { get; }
		BoolReactiveProperty IsDead { get; }

		void Initialize(int health);
		void TakeDamage(int damage);
		void Kill();
	}
}
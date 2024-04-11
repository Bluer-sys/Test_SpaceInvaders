using UniRx;

namespace Hero.Interfaces
{
	public interface IHeroDataStorage
	{
		IntReactiveProperty Score { get; }
	}
}
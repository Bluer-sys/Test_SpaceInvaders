using Configuration;
using JetBrains.Annotations;
using Unit.Interfaces;

namespace Hero
{
	[UsedImplicitly]
	public class HeroInitializer
	{
		public HeroInitializer(IUnitHealth unitHealth, GameConfig gameConfig)
		{
			unitHealth.Initialize( gameConfig.HeroHealth );
		}
	}
}
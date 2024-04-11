using JetBrains.Annotations;
using Zenject;

namespace Enemy.Factory
{
	[UsedImplicitly]
	public class EnemyFactory : PlaceholderFactory< EnemyModel, EnemyFacade > {}
}
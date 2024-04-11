using System.Collections.Generic;
using UniRx;

namespace Enemy.Interfaces
{
	public interface IEnemySpawner
	{
		IReadOnlyList<IEnemyFacade> SpawnedEnemies { get; }
		ReactiveCommand<IEnemyFacade> OnEnemyDead { get; }
	}
}
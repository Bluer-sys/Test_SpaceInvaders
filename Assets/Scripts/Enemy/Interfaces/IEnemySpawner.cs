using System.Collections.Generic;
using UniRx;

namespace Enemy.Interfaces
{
	public interface IEnemySpawner
	{
		IReadOnlyList<IEnemyFacade> SpawnedEnemies { get; }
		ReactiveCommand<IEnemyFacade> OnEnemyDead { get; }
		void SpawnGrid(int row, int column, float difficultyMultiplier = 1.0f);
	}
}
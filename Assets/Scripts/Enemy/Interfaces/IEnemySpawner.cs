using System.Collections.Generic;

namespace Enemy.Interfaces
{
	public interface IEnemySpawner
	{
		IReadOnlyList<IEnemyFacade> SpawnedEnemies { get; }
	}
}
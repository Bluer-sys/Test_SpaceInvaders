using Configuration;
using JetBrains.Annotations;
using Zenject;

namespace Enemy.Factory
{
	[UsedImplicitly]
	public class EnemyPrefabFactory : PrefabFactory<EnemyFacade>, IFactory<EnemyModel, EnemyFacade>
	{
		private readonly PrefabsConfig _prefabsConfig;

		public EnemyPrefabFactory(PrefabsConfig prefabsConfig)
		{
			_prefabsConfig = prefabsConfig;
		}

		public EnemyFacade Create(EnemyModel model)
		{
			EnemyFacade enemyFacade = base.Create( _prefabsConfig.EnemyPrefab );
			
			enemyFacade.Initialize( model );
			
			return enemyFacade;
		}
	}
}
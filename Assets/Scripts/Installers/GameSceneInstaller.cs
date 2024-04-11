using Bullet;
using Configuration;
using Enemy;
using Enemy.Factory;
using Enemy.Interfaces;
using Hero;
using Hero.Interfaces;
using Input;
using Utilities;
using Zenject;

namespace Installers
{
	public class GameSceneInstaller : MonoInstaller
	{
		private const int BulletPoolInitialSize = 10;
		private const int EnemyPoolInitialSize = 5;
		
		private PrefabsConfig _prefabsConfig;

		[Inject]
		private void Construct(PrefabsConfig prefabsConfig)
		{
			_prefabsConfig = prefabsConfig;
		}
		
		public override void InstallBindings()
		{
			Container.Bind<ScreenWorld>().AsSingle().NonLazy();
			
			Container.BindInterfacesTo<PlayerInput>().AsSingle();
			Container.Bind<IHeroFacade>().To<HeroFacade>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesTo<ObjectsLifetimeController>().AsSingle();

			Container
				.BindFactory<EnemyModel, EnemyFacade, EnemyFactory>()
				.FromFactory<EnemyPrefabFactory>();
			
			Container.BindInterfacesTo<EnemySpawner>().AsSingle();
			
			Container
				.BindMemoryPool< Bullet.Bullet, BulletPool >()
				.WithInitialSize( BulletPoolInitialSize )
				.ExpandByOneAtATime()
				.FromComponentInNewPrefab( _prefabsConfig.BulletPrefab )
				.UnderTransformGroup( "BulletPool" );
		}
	}
}
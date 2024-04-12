using Bullet;
using Configuration;
using Enemy;
using Enemy.Factory;
using Enemy.Interfaces;
using Gameplay;
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
		
		private PrefabsConfig _prefabsConfig;

		[Inject]
		private void Construct(PrefabsConfig prefabsConfig)
		{
			_prefabsConfig = prefabsConfig;
		}
		
		public override void InstallBindings()
		{
			Container.Bind<ScreenWorld>().AsSingle().NonLazy();
			Container.BindInterfacesTo<ObjectsLifetimeController>().AsSingle();

			// input
			Container.BindInterfacesTo<PlayerInput>().AsSingle();

			// Hero
			Container.Bind<IHeroFacade>().To<HeroFacade>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesTo<HeroDeathObserver>().AsSingle();
			
			// Enemy
			Container.BindInterfacesTo<WavesController>().AsSingle();
			Container.BindFactory<EnemyModel, EnemyFacade, EnemyFactory>().FromFactory<EnemyPrefabFactory>();
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
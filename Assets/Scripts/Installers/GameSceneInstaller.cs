using Bullet;
using Configuration;
using Hero;
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
			Container.Bind<ScreenBorder>().AsSingle().NonLazy();
			
			Container.BindInterfacesTo<PlayerInput>().AsSingle();
			Container.Bind<IHeroFacade>().To<HeroFacade>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesTo<ObjectsLifetimeController>().AsSingle();
			
			Container
				.BindMemoryPool< Bullet.Bullet, BulletPool >()
				.WithInitialSize( BulletPoolInitialSize )
				.ExpandByOneAtATime()
				.FromComponentInNewPrefab( _prefabsConfig._simpleBulletPrefab )
				.UnderTransformGroup( "BulletPool" );
		}
	}
}
using Bullet;
using Bullet.Base;
using Data;
using Hero;
using Input;
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
			Container.BindInterfacesTo<PlayerInput>().AsSingle();
			Container.Bind<IHeroFacade>().To<HeroFacade>().FromComponentInHierarchy().AsSingle();
			
			Container
				.BindMemoryPool< HeroBullet, BulletPool >()
				.WithInitialSize( BulletPoolInitialSize )
				.ExpandByOneAtATime()
				.FromComponentInNewPrefab( _prefabsConfig.HeroBulletPrefab )
				.UnderTransformGroup( "HeroBullets" );
		}
	}
}
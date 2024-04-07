using Hero;
using Zenject;

namespace Installers
{
	public class HeroInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInstance( transform ).AsSingle();
			Container.Bind<HeroMovement>().AsSingle().NonLazy();
		}
	}
}
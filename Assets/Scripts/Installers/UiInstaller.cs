using UI;
using UI.Interfaces;
using Zenject;

namespace Installers
{
	public class UiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<UiController>().AsSingle();
			Container.Bind<IUiView>().To<UiView>().FromComponentInHierarchy().AsSingle();
		}
	}
}
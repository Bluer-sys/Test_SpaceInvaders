using UI;
using UI.Interfaces;
using Zenject;

namespace Installers
{
	public class UiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<UiTopPanelController>().AsSingle();
			Container.Bind<IUiTopPanelView>().To<UiTopPanelView>().FromComponentInHierarchy().AsSingle();
			
			// Screen
			Container.Bind<IPauseScreen>().To<PauseScreen>().FromComponentInHierarchy().AsSingle();
		}
	}
}
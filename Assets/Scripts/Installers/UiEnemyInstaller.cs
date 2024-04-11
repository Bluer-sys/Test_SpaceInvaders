using UI;
using UI.Interfaces;
using Zenject;

namespace Installers
{
	public class UiEnemyInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<UiEnemyController>().AsSingle();
			Container.Bind<IUiEnemyView>().To<UiEnemyView>().FromComponentInHierarchy().AsSingle();
		}
	}
}
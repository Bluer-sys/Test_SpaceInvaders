using Enemy;
using Enemy.Interfaces;
using Unit;
using Unit.Interfaces;
using Zenject;

namespace Installers
{
	public class EnemyInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInstance( transform ).AsSingle();
			
			Container.BindInterfacesTo<EnemyMovement>().AsSingle();
			Container.Bind<IUnitHealth>().To<UnitHealth>().AsSingle();
		}
	}
}
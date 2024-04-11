using Enemy;
using Zenject;

namespace Installers
{
	public class EnemyInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInstance( transform ).AsSingle();
			
			Container.Bind<EnemyMovement>().AsSingle().NonLazy();
		}
	}
}
using UnityEngine;
using Utilities;
using Zenject;

namespace Installers
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BulletInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Rigidbody2D rb = GetComponent<Rigidbody2D>();

			Container.BindInstance( rb );
			Container.BindInstance( transform );

			Container.Bind<TriggerObserver>().FromComponentInHierarchy().AsSingle();
		}
	}
}
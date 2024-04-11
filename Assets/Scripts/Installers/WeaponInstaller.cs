using Configuration;
using UnityEngine;
using Weapon.Base;
using Zenject;

namespace Installers
{
	public class WeaponInstaller : MonoInstaller
	{
		[SerializeField] private WeaponConfig _weaponConfig;
		
		public override void InstallBindings()
		{
			Container.BindInstance( _weaponConfig ).AsSingle();
			
			Container.Bind<WeaponBase>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<Muzzle>().FromComponentsInHierarchy().AsSingle();
		}
	}
}
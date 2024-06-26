﻿using Hero;
using Unit;
using Unit.Interfaces;
using Zenject;

namespace Installers
{
	public class HeroInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInstance( transform ).AsSingle();

			Container.Bind<IUnitHealth>().To<UnitHealth>().AsSingle();
			Container.Bind<HeroMovement>().AsSingle().NonLazy();
			Container.BindInterfacesTo<HeroDataStorage>().AsSingle();
			Container.Bind<HeroInitializer>().AsSingle().NonLazy();
		}
	}
}
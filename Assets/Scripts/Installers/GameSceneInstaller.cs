﻿using Input;
using Zenject;

namespace Installers
{
	public class GameSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<PlayerInput>().AsSingle();
		}
	}
}
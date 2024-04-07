using Data;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField] 
		private GameConfig _gameConfig;
		
		public override void InstallBindings()
		{
			Container.BindInstance( _gameConfig ).AsSingle();
		}
	}
}
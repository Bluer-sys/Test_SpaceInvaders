using Configuration;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField] 
		private GameConfig _gameConfig;
		
		[SerializeField] 
		private PrefabsConfig _prefabsConfig;
		
		public override void InstallBindings()
		{
			Container.BindInstance( _gameConfig ).AsSingle();
			Container.BindInstance( _prefabsConfig ).AsSingle();
		}
	}
}
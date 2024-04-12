using Gameplay.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
	[UsedImplicitly]
	public class GameController : IGameController
	{
		public void Restart()
		{
			SceneManager.LoadScene( "Game" );
			UnfreezeTime();
		}

		public void FreezeTime()
		{
			Time.timeScale = 0;
		}

		public void UnfreezeTime()
		{
			Time.timeScale = 1;
		}
	}
}
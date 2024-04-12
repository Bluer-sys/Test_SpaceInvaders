using Gameplay.Interfaces;
using UI.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public class PauseScreen : MonoBehaviour, IPauseScreen
	{
		[SerializeField]
		private Button _restartButton;

		[SerializeField]
		private Button _closeButton;

		private IGameController _gameController;

		[Inject]
		private void Construct(IGameController gameController)
		{
			_gameController = gameController;
			
			_restartButton.OnClickAsObservable()
				.Subscribe( _ => gameController.Restart() )
				.AddTo( this );
			
			_closeButton.OnClickAsObservable()
				.Subscribe( _ => Close() )
				.AddTo( this );
		}

		public void Show()
		{
			_gameController.FreezeTime();
			gameObject.SetActive( true );
		}

		private void Close()
		{
			_gameController.UnfreezeTime();
			gameObject.SetActive( false );
		}
	}
}
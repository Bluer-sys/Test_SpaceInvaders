using System;

namespace UI.Interfaces
{
	public interface IUiTopPanelView
	{
		IObservable<UniRx.Unit> OnPause { get; }
		
		void SetHealth(int health, int maxHealth);
		void SetScore(int value);
	}
}
using System;

namespace UI.Interfaces
{
	public interface IUiView
	{
		IObservable<UniRx.Unit> OnRestart { get; }
		
		void SetHealth(int health, int maxHealth);
		void SetScore(int value);
	}
}
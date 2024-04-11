using System;
using TMPro;
using UI.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UiView : MonoBehaviour, IUiView
	{
		[SerializeField] 
		private Image _healthBar;

		[SerializeField] 
		private TextMeshProUGUI _score;
		
		[SerializeField]
		private Button _restartButton;
		
		public IObservable<UniRx.Unit> OnRestart => _restartButton.OnClickAsObservable();
		
		public void SetHealth(int health, int maxHealth)
		{
			_healthBar.fillAmount = (float) health / maxHealth;
		}

		public void SetScore(int value)
		{
			_score.text = $"Score: {value}";
		}
	}
}
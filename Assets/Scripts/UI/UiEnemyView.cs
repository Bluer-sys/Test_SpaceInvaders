using UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UiEnemyView : MonoBehaviour, IUiEnemyView
	{
		[SerializeField] 
		private Image _healthBar;
		
		[SerializeField]
		private GameObject _healthObject;
		
		public void SetHealth(int health, int maxHealth)
		{
			_healthBar.fillAmount = (float) health / maxHealth;
		}

		public void SetActive(bool isActive)
		{
			_healthObject.SetActive( isActive );
		}
	}
}
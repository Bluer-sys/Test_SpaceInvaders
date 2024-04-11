using UniRx;
using UnityEngine;

namespace Utilities
{
	public class TriggerObserver : MonoBehaviour
	{
		public ReactiveCommand<Collider2D> OnTriggerEnter { get; } = new();
	
		private void OnTriggerEnter2D(Collider2D other)
		{
			OnTriggerEnter.Execute( other );
		}
	}
}
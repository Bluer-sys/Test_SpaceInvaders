using Data;
using Extensions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(RawImage))]
public class BackgroundScroller : MonoBehaviour
{
	private GameConfig _gameConfig;
	private RawImage _rawImage;
	
	[Inject]
	public void Construct(GameConfig gameConfig)
	{
		_gameConfig = gameConfig;
		
		_rawImage = GetComponent<RawImage>();
	}

	private void Update()
	{
		float newY = _rawImage.uvRect.y + _gameConfig.BackgroundScrollSpeed * Time.deltaTime;
		newY %= 1.0f;

		_rawImage.uvRect = _rawImage.uvRect.WithY( newY );
	}
}
using JetBrains.Annotations;
using UnityEngine;

namespace Utilities
{
	[UsedImplicitly]
	public class ScreenWorld
	{
		public static float Left { get; private set; }
		public static float Right { get; private set; }
		public static float Top { get; private set; }
		public static float Bottom { get; private set; }

		public ScreenWorld()
		{
			CalcBorders();
		}

		private void CalcBorders()
		{
			var camera = Camera.main;
			
			Vector3 min = camera!.ViewportToWorldPoint( new Vector3( 0, 0, 0 ) );
			Vector3 max = camera.ViewportToWorldPoint( new Vector3( 1, 1, 0 ) );

			Top = max.y;
			Bottom = min.y;
			Left = min.x;
			Right = max.x;
		}
	}
}
using UnityEngine;

namespace Extensions
{
	public static class Extensions
	{
		public static Rect WithY(this Rect rect, float y) => new( rect.x, y, rect.width, rect.height );

		public static float Random(this Vector2 v) => UnityEngine.Random.Range( v.x, v.y );
		public static int Random(this Vector2Int v) => UnityEngine.Random.Range( v.x, v.y );
	}
}
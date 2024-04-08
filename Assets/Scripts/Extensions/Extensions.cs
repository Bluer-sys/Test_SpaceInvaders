using UnityEngine;

namespace Extensions
{
	public static class Extensions
	{
		public static Rect WithY(this Rect rect, float y) => new( rect.x, y, rect.width, rect.height );
	}
}
using System;
using System.Text.Json.Serialization;

namespace MindboxTaskDolgikh
{
	public struct Point
	{
		public double X { get; }
		public double Y { get; }

		[JsonConstructor]
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			return obj is Point point &&
				   X == point.X &&
				   Y == point.Y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}
	}
}

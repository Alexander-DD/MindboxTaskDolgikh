using System;

namespace MindboxTaskDolgikh.Shapes
{
	public class Segment
	{
		private const double EPSILON = 0.000000000001;
		public Point PointA { get; private set; }
		public Point PointB { get; private set; }

		public Segment(Point pointA, Point pointB)
		{
			PointA = pointA;
			PointB = pointB;
		}

		private double GetDeterminant(Segment segment, Point point)
		{
			return ((segment.PointB.X - segment.PointA.X) * (point.Y - segment.PointA.Y) - (segment.PointB.Y - segment.PointA.Y) * (point.X - segment.PointA.X));
		}

		public bool Contains(Point point)
		{
			double determinant = GetDeterminant(new Segment(PointA, PointB), point);

			return ContainsInOutscribedRectangle(point, determinant);
		}

		private bool ContainsInOutscribedRectangle(Point point, double determinant)
		{
			double XLeft, XRight, YBottom, YTop;

			if (PointA.X < PointB.X)
			{
				XLeft = PointA.X;
				XRight = PointB.X;
			}
			else
			{
				XLeft = PointB.X;
				XRight = PointA.X;
			}

			if (PointA.Y < PointB.Y)
			{
				YBottom = PointA.Y;
				YTop = PointB.Y;
			}
			else
			{
				YBottom = PointB.Y;
				YTop = PointA.Y;
			}

			return Math.Abs(determinant) < EPSILON && XLeft <= point.X && point.X <= XRight && YBottom <= point.Y && point.Y <= YTop;
		}

		public bool Intersects(Segment another)
		{
			// Быстрый отказ (по описывающим прямоугольникам). Ускоряет работу алгоритма.
			if (Math.Max(PointA.X, PointB.X) < Math.Min(another.PointA.X, another.PointB.X) ||
				Math.Min(PointA.X, PointB.X) > Math.Max(another.PointA.X, another.PointB.X) ||
				Math.Max(PointA.Y, PointB.Y) < Math.Min(another.PointA.Y, another.PointB.Y) ||
				Math.Min(PointA.Y, PointB.Y) > Math.Max(another.PointA.Y, another.PointB.Y))
			{
				return false;
			}

			double detThisSegmentAnotherA = GetDeterminant(this, another.PointA);
			double detThisSegmentAnotherB = GetDeterminant(this, another.PointB);
			double detAnotherSegmentThisA = GetDeterminant(another, PointA);
			double detAnotherSegmentThisB = GetDeterminant(another, PointB);

			// Принадлежность точки отрезку.
			if (Math.Abs(detThisSegmentAnotherA) < EPSILON && ContainsInOutscribedRectangle(another.PointA, detThisSegmentAnotherA) ||
				Math.Abs(detThisSegmentAnotherB) < EPSILON && ContainsInOutscribedRectangle(another.PointB, detThisSegmentAnotherB) ||
				Math.Abs(detAnotherSegmentThisA) < EPSILON && another.ContainsInOutscribedRectangle(PointA, detAnotherSegmentThisA) ||
				Math.Abs(detAnotherSegmentThisB) < EPSILON && another.ContainsInOutscribedRectangle(PointB, detAnotherSegmentThisB))
			{
				return true;
			}

			// По векторному умножению.
			if (detThisSegmentAnotherA > 0 && detThisSegmentAnotherB < 0 && detAnotherSegmentThisA < 0 && detAnotherSegmentThisB > 0 ||
				detThisSegmentAnotherA < 0 && detThisSegmentAnotherB > 0 && detAnotherSegmentThisA > 0 && detAnotherSegmentThisB < 0)
			{
				return true;
			}

			return false;
		}
	}
}

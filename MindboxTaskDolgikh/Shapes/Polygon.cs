using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MindboxTaskDolgikh.Shapes
{
	public class Polygon : IShape, IValidatable
	{
		private List<Point> points;

		internal Polygon(List<Point> points)
		{
			this.points = points;
		}

		public double GetArea()
		{
			var workPoints = new List<Point>(points);
			// Copy from: https://stackoverflow.com/a/16281192

			workPoints.Add(workPoints[0]);
			double area = Math.Abs(workPoints.Take(workPoints.Count - 1)
			   .Select((p, i) => (workPoints[i + 1].X - p.X) * (workPoints[i + 1].Y + p.Y))
			   .Sum() / 2);

			return area;
		}

		void IValidatable.Validate()
		{
			if (points.Count < 2)
			{
				throw new ValidationException("В полигоне меньше двух точек.");
			}

			if (IsComplex)
			{
				throw new ValidationException("Этот полигон является не простым (с пересекающимися сторонами), данная библиотека не поддерживает работу с такими объектами.");
			}
		}

		public override string ToString()
		{
			return $"Простой многоугольник с количеством вершин: {points.Count}";
		}

		// Проверка, является ли полигон, образуемый точками, не простым (с пересекающимися сторонами).
		private bool IsComplex
		{
			get
			{
				if (points.Count < 4) // Все полигоны до 4 точек не могут самопересечься.
				{
					return false;
				}

				// Перевод точек в отрезки.
				List<Segment> segments = new List<Segment>();
				for (int i = 1; i < points.Count; i++)
				{
					segments.Add(new Segment(points[i - 1], points[i]));
				}
				segments.Add(new Segment(points[points.Count - 1], points[0]));

				// Нас интересуют только отрезки не идущие следом друг за другом.
				List<Tuple<Segment, Segment>> segmentPairs = new List<Tuple<Segment, Segment>>();
				for (int i = 0; i < segments.Count - 2; i++)
				{
					for (int j = i + 2; j < segments.Count; j++)
					{
						if (segments[i].PointA.Equals(segments[j].PointB)) continue;

						segmentPairs.Add(new Tuple<Segment, Segment>(segments[i], segments[j]));
					}
				}

				return segmentPairs.Any(pair => pair.Item1.Intersects(pair.Item2));
			}
		}
	}
}

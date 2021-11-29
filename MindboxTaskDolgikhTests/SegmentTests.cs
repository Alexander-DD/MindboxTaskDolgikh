using MindboxTaskDolgikh;
using MindboxTaskDolgikh.Shapes;
using System.Collections.Generic;
using Xunit;

namespace MindboxTaskDolgikhTests
{
	public class SegmentTests
	{
		[Theory]
		[InlineData(-1, 0, 1, 0, 0, 0)] // Горизонтальный отрезок, точка внутри промежутка.
		[InlineData(0, -1, 0, 1, 0, 0)] // Вертикальный отрезок, точка внутри промежутка.
		[InlineData(-1, -1, 1, 1, 0.5, 0.5)] // Диагональный отрезок, точка внутри промежутка.
		[InlineData(1, 1, -1, -1, 0.5, 0.5)] // Диагональный отрезок, начало в первой четверти, конец в третьей, точка внутри промежутка.
		[InlineData(-1, -1, 1, 1, -1, -1)] // Диагональный отрезок, проверяемая точка совпадает с точкой A.
		[InlineData(-1, -1, 1, 1, 1, 1)] // Диагональный отрезок, проверяемая точка совпадает с точкой B.
		[InlineData(-1, 1.33333333333333, 4, 3, 1, 2)] // Диагональный отрезок с дробным результатом вычислений.
		[InlineData(13.255, 36.01, -24.17, 34.92, 12.4, 35.9850981963928)] // Диагональный отрезок с дробным результатом вычислений.
		public void Contains_returnsTrue(double Ax, double Ay, double Bx, double By, double x, double y)
		{
			// Arrange
			Segment segment = new Segment(new Point(Ax, Ay), new Point(Bx, By));
			Point point = new Point(x, y);

			// Act
			bool res = segment.Contains(point);

			// Assert
			Assert.True(res);
		}

		[Theory]
		[InlineData(-1, 0, 1, 0, 2, 0)] // Горизонтальный отрезок, точка на линии, но вне отрезка.
		[InlineData(0, -1, 0, 1, 0, 2)] // Вертикальный отрезок, точка на линии, но вне отрезка.
		[InlineData(-1, -1, 1, 1, 2, 2)] // Диагональный отрезок, точка на линии, но вне отрезка.
		[InlineData(1, 2, 4, 3, -1, 1.3333333333)] // Диагональный отрезок с дробным результатом вычислений, точка на линии, но вне отрезка.
		[InlineData(-1, -1, 1, 1, 17, 6)] // Диагональный отрезок, точка вне отрезка и вне линии.
		[InlineData(13.255, 36.01, -24.17, 34.92, 12.4, 34.1)] // Диагональный отрезок с дробным результатом вычислений.
		public void Contains_returnsFalse(double Ax, double Ay, double Bx, double By, double x, double y)
		{
			// Arrange
			Segment segment = new Segment(new Point(Ax, Ay), new Point(Bx, By));
			Point point = new Point(x, y);

			// Act
			bool res = segment.Contains(point);

			// Assert
			Assert.False(res);
		}

		public static IEnumerable<object[]> IntersectingSegmentData
		{
			get
			{
				return new[]
				{
					// Перекрестие по осям X и Y с центром в (0; 0).
					new object[] { new Segment(new Point(0, -1), new Point(0, 1)), new Segment(new Point(-1, 0), new Point(1, 0))},

					// Диагональное перекрестие с центром в (2; 2).
					new object[] { new Segment(new Point(1, 1), new Point(3, 3)), new Segment(new Point(3, 1), new Point(1, 3))},

					// Инициализация отрезка с большего значения в начале промежутка.
					new object[] { new Segment(new Point(3, 3), new Point(1, 1)), new Segment(new Point(3, 1), new Point(1, 3))},
					
					// Совпадение концов отрезков.
					new object[] { new Segment(new Point(1.1, 0.93), new Point(52.49, 41.22)), new Segment(new Point(21.28, -4.7), new Point(52.49, 41.22))},

					// Конец отрезка лежит на другом отрезке.
					new object[] { new Segment(new Point(13.255, 36.01), new Point(-24.17, 34.92)), new Segment(new Point(-1.28, 2.7), new Point(12.4, 35.9850981963928))},

					// Пересечение отрезков с дробными расчетами.
					new object[] { new Segment(new Point(1.1, 0.93), new Point(52.49, 41.22)), new Segment(new Point(21.28, -4.7), new Point(-2.1, 10.008))},
				};
			}
		}

		[Theory, MemberData(nameof(IntersectingSegmentData))]
		public void Intersects_returnsTrue(Segment segmentOne, Segment segmentTwo)
		{
			// Arrange

			// Act
			bool res = segmentOne.Intersects(segmentTwo);

			// Assert
			Assert.True(res);
		}

		public static IEnumerable<object[]> NotIntersectingSegmentData
		{
			get
			{
				return new[]
				{
					// Два параллельных вертикальных отрезка.
					new object[] { new Segment(new Point(-1, -1), new Point(-1, 1)), new Segment(new Point(1, 1), new Point(1, -1))}, 

					// Два параллельных горизонтальных отрезка.
					new object[] { new Segment(new Point(-1, 1), new Point(1, 1)), new Segment(new Point(-1, -1), new Point(1, -1))}, 

					// Диагональные параллельные отрезки.
					new object[] { new Segment(new Point(0, -1), new Point(2, 0)), new Segment(new Point(0, 1), new Point(2, 2))}, 
					
					// Диагональные отрезки.
					new object[] { new Segment(new Point(1, 1), new Point(3, 2)), new Segment(new Point(6, -6), new Point(7, -5))}, 

					// Пересечение продолжения линии отрезка с другим отрезком, но не самих отрезков.
					new object[] { new Segment(new Point(-50.1, 1.26), new Point(52.49, 2.98)), new Segment(new Point(0.77, -4.7), new Point(0.98, -0.08))},
				};
			}
		}

		[Theory, MemberData(nameof(NotIntersectingSegmentData))]
		public void Intersects_returnsFalse(Segment segmentOne, Segment segmentTwo)
		{
			// Arrange

			// Act
			bool res = segmentOne.Intersects(segmentTwo);

			// Assert
			Assert.False(res);
		}
	}
}
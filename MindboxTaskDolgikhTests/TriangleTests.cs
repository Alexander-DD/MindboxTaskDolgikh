using MindboxTaskDolgikh;
using MindboxTaskDolgikh.Shapes;
using System;
using Xunit;

namespace MindboxTaskDolgikhTests
{
	public class TriangleTests
	{
		private const double EPSILON = 0.00000001;

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(2, 6, 5)]
		[InlineData(5.08, 3.77, 8.2)]
		public void Validate_returnsTrue(double a, double b, double c)
		{
			// Arrange
			// Act
			Result<Triangle> res = ShapeFactory.CreateTriangle(a, b, c);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Theory]
		[InlineData(-1, 1, 3)]
		[InlineData(1, -1, 3)]
		[InlineData(1, 1, -3)]
		[InlineData(532132, 2, 4)]
		[InlineData(5, 222464.58212, 9)]
		[InlineData(5, 2, 99994848)]
		
		public void Validate_returnsFalse(double a, double b, double c)
		{
			// Arrange
			// Act
			Result<Triangle> res = ShapeFactory.CreateTriangle(a, b, c);

			// Assert
			Assert.False(res.IsSuccess);
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(2, 6, 4, 0)]
		[InlineData(2, 6, 5, 4.6837484987987983)]
		[InlineData(5.42861, 2.58212, 6.8426315, 6.4796977319966667)]
		public void GetArea_returnsArea(double a, double b, double c, double area)
		{
			// Arrange
			Result<Triangle> res = ShapeFactory.CreateTriangle(a, b, c);

			// Act
			double actual = res.Value.GetArea();

			// Assert
			Assert.True(Math.Abs(actual - area) < EPSILON);
		}


		[Theory]
		[InlineData(3, 4, 5)]
		[InlineData(5.6, 9.3, 10.85587398600407)]
		public void IsRightTriangle_returnsTrue(double a, double b, double c)
		{
			// Arrange
			Result<Triangle> res = ShapeFactory.CreateTriangle(a, b, c);

			// Act
			bool actual = res.Value.IsRightTriangle;

			// Assert
			Assert.True(actual);
		}

		[Theory]
		[InlineData(4, 7, 10)]
		[InlineData(4.6, 8.3, 9.8)]
		public void IsRightTriangle_returnsFalse(double a, double b, double c)
		{
			// Arrange
			Result<Triangle> res = ShapeFactory.CreateTriangle(a, b, c);

			// Act
			bool actual = res.Value.IsRightTriangle;

			// Assert
			Assert.False(actual);
		}
	}
}
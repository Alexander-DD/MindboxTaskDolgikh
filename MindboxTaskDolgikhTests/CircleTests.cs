using MindboxTaskDolgikh;
using MindboxTaskDolgikh.Shapes;
using System;
using Xunit;

namespace MindboxTaskDolgikhTests
{
	public class CircleTests
	{
		private const double EPSILON = 0.00000001;

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(5.08)]
		[InlineData(3000)]
		public void Validate_returnsTrue(double radius)
		{
			// Arrange
			// Act
			Result<Circle> res = ShapeFactory.CreateCircle(radius);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-5.08)]
		public void Validate_returnsFalse(double radius)
		{
			// Arrange
			// Act
			Result<Circle> res = ShapeFactory.CreateCircle(radius);

			// Assert
			Assert.False(res.IsSuccess);
		}

		[Theory]
		[InlineData(0, 0)]
		[InlineData(1, Math.PI)]
		[InlineData(5.42861, 92.582127703957861292734820938)]
		[InlineData(3000, 28274333.8823081391461)]
		public void GetArea_returnsTrue(double radius, double area)
		{
			// Arrange
			Result<Circle> res = ShapeFactory.CreateCircle(radius);

			// Act
			double actual = res.Value.GetArea();

			// Assert
			Assert.True(Math.Abs(actual - area) < EPSILON);
		}
	}
}

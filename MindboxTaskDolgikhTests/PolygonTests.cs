using MindboxTaskDolgikh;
using MindboxTaskDolgikh.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Xunit;

namespace MindboxTaskDolgikhTests
{
	public class PolygonTests
	{
		private const double EPSILON = 0.00000001;

		[Fact]
		public void Validate_TwoPoints_returnsTrue()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Fact]
		public void Validate_ThreePoints_returnsTrue()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(1, 0)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Fact]
		public void Validate_SimplePolygon_returnsTrue()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(1, 1),
				new Point(1, -1)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Fact]
		public void Validate_OddCountOfPoints_returnsTrue()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(1, 1),
				new Point(1, -1),
				new Point(0, -2)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Fact]
		public void Validate_ConvexPolygon_returnsTrue()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(3, 3),
				new Point(1, 1),
				new Point(1, -1),
				new Point(0, -2)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.True(res.IsSuccess);
		}

		[Fact]
		public void Validate_LowCountOfPoints_returnsFalse()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.False(res.IsSuccess);
		}

		[Fact]
		public void Validate_ComplexPolygon_returnsFalse()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(1, -1),
				new Point(1, 1)
			};

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.False(res.IsSuccess);
		}

		[Fact]
		public void GetArea_TwoPoints_returnsZero()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1)
			};

			double area = 0;

			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Act
			double actual = res.Value.GetArea();

			// Assert
			Assert.True(Math.Abs(actual - area) < EPSILON);
		}

		[Fact]
		public void GetArea_ThreePoints_returnsArea()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(1, -1)
			};

			double area = 2;

			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Act
			double actual = res.Value.GetArea();

			// Assert
			Assert.True(Math.Abs(actual - area) < EPSILON);
		}

		[Fact]
		public void GetArea_SimplePolygon_returnsArea()
		{
			// Arrange
			var points = new List<Point>
			{
				new Point(-1, -1),
				new Point(-1, 1),
				new Point(1, 1),
				new Point(1, -1)
			};

			double area = 4;

			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Act
			double actual = res.Value.GetArea();

			// Assert
			Assert.True(Math.Abs(actual - area) < EPSILON);
		}

		[Fact]
		public void Validate_MoscowRegion_returnsTrue()
		{
			// Arrange
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\MoscowRegionDataset.json");
			string jsonString = File.ReadAllText(path);
			List<Point> points = JsonSerializer.Deserialize<List<Point>>(jsonString);

			// Act
			Result<Polygon> res = ShapeFactory.CreatePolygon(points);

			// Assert
			Assert.True(res.IsSuccess);
		}
	}
}
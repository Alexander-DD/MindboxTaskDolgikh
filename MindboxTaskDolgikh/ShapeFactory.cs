using MindboxTaskDolgikh.Shapes;
using System;
using System.Collections.Generic;

namespace MindboxTaskDolgikh
{
	public class ShapeFactory
	{
		public static Result<Circle> CreateCircle(double radius)
		{
			var circle = new Circle(radius);
			return WrapResult(circle);
		}

		public static Result<Triangle> CreateTriangle(double a, double b, double c)
		{
			var triangle = new Triangle(a, b, c);
			return WrapResult(triangle);
		}

		public static Result<Polygon> CreatePolygon(List<Point> points)
		{
			var polygon = new Polygon(points);
			return WrapResult(polygon);
		}

		private static Result<ShapeType> WrapResult<ShapeType>(ShapeType shape) where ShapeType : IShape, IValidatable
		{
			try
			{
				shape.Validate();
				return Result<ShapeType>.Success(shape);
			}
			catch (Exception e)
			{
				return Result<ShapeType>.Failure(e);
			}
		}
	}
}
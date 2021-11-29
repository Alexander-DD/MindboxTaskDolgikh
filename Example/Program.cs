using MindboxTaskDolgikh;
using MindboxTaskDolgikh.Shapes;
using System;
using System.Collections.Generic;

namespace Example
{
	class Program
	{
		private static void Show(Result<IShape> shapeResult)
		{
			if (shapeResult.IsSuccess)
			{
				IShape shape = shapeResult.Value;
				Console.WriteLine("^^^^^^^^^^^^^^^^^^^^");
				Console.WriteLine($"Для фигуры: *{shape}*: Площадь = {shape.GetArea()}");

				if (shapeResult.Value is Triangle)
				{
					var triangle = (Triangle)shapeResult.Value;
					if (triangle.IsRightTriangle)
					{
						Console.WriteLine("Треугольник прямоугольный");
					}
					else
					{
						Console.WriteLine("Треугольник НЕ прямоугольный");
					}
				}

				Console.WriteLine("vvvvvvvvvvvvvvvvvvvvv");
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine(shapeResult.Exception.Message);
			}
		}

		static void Main(string[] args)
		{
			// Круг.
			Result<Circle> circleResult = ShapeFactory.CreateCircle(11);
			Show(circleResult.Cast());

			// Треугольник.
			Result<Triangle> triangleResult = ShapeFactory.CreateTriangle(5, 4, 3);
			Show(triangleResult.Cast());

			// Полигон (Площадь фигуры без знания типа фигуры).
			Result<Polygon> polygonResult = ShapeFactory.CreatePolygon(new List<Point>() { 
				new Point(0.1, 0.43),
				new Point(5.17, 7.02),
				new Point(9.9, 15.84),
				new Point(10.001, 1)});
			Show(polygonResult.Cast());

			// Список фигур.
			List<Result<IShape>> shapeResults = new List<Result<IShape>>();
			shapeResults.Add(circleResult.Cast());
			shapeResults.Add(triangleResult.Cast());
			shapeResults.Add(polygonResult.Cast());
			foreach (var result in shapeResults)
			{
				Show(result);
			}
		}
	}
}

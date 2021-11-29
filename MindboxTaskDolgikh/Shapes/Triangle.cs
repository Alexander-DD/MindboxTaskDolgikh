using System;
using System.ComponentModel.DataAnnotations;

namespace MindboxTaskDolgikh.Shapes
{
	public class Triangle : IShape, IValidatable
	{
		private double a;
		private double b;
		private double c;

		private const double EPSILON = 0.000001;

		internal Triangle(double a, double b, double c)
		{
			this.a = a;
			this.b = b;
			this.c = c;
		}

		public double GetArea()
		{
			double halfPerimeter = (a + b + c) / 2;

			return Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
		}

		void IValidatable.Validate()
		{
			if (a < 0 || b < 0 || c < 0)
			{
				throw new ValidationException("Одна из сторон меньше нуля.");
			}

			// Проверка треугольника на существование.
			if (a + b < c || a + c < b || b + c < a)
			{
				throw new ValidationException("Треугольника по заданным параметрам не существует.");
			}
		}

		public override string ToString()
		{
			return $"Треугольник со сторонами a = {a}, b = {b}, c = {c}";
		}

		public bool IsRightTriangle => 
			Math.Abs(a * a + b * b  - c * c ) < EPSILON || 
			Math.Abs(a * a + c * c - b * b) < EPSILON || 
			Math.Abs(b * b + c * c - a * a) < EPSILON;
	}
}

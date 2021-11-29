using System;
using System.ComponentModel.DataAnnotations;

//[assembly: InternalsVisibleTo("MindboxTaskDolgikhTests")]
namespace MindboxTaskDolgikh.Shapes
{
	public class Circle : IShape, IValidatable
	{
		private double radius;

		internal Circle(double radius)
		{
			this.radius = radius;
		}

		public double GetArea()
		{
			return Math.PI * radius * radius;
		}

		void IValidatable.Validate()
		{
			if (radius < 0)
			{
				throw new ValidationException("Радиус круга меньше нуля.");
			}
		}

		public override string ToString()
		{
			return $"Круг с радиусом = {radius}";
		}
	}
}

using MindboxTaskDolgikh.Shapes;
using System;

namespace MindboxTaskDolgikh
{
	public class Result<T> where T : IShape
	{
		private Result(T value) 
		{
			Value = value;
		}

		private Result(Exception exception) 
		{
			Exception = exception;
		}

		public T Value { get; }

		public Exception Exception { get; } = null;

		public bool IsSuccess => Value != null && Exception == null;

		internal static Result<T> Success(IShape shape)
		{
			return new Result<T>((T)shape);
		}

		internal static Result<T> Failure(Exception e)
		{
			return new Result<T>(e);
		}

		public Result<IShape> Cast()
		{
			return new Result<IShape>(Value);
		}
	}
}

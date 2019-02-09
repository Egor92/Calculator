using System;

namespace Calculator.BusinessLogic
{
	public class BinaryOperation
	{
		private readonly string _name;
		private readonly Func<double, double, double> _func;

		public BinaryOperation(string name, Func<double, double, double> func)
		{
			_name = name;
			_func = func;
		}

		public override string ToString()
		{
			return _name;
		}

		public double Execute(double value1, double value2)
		{
			return _func(value1, value2);
		}
	}

	public static class BinaryOperations
	{
		public static readonly BinaryOperation Addition = new BinaryOperation(nameof(Addition), (x1, x2) => x1 + x2);
		public static readonly BinaryOperation Subtraction = new BinaryOperation(nameof(Subtraction), (x1, x2) => x1 - x2);
		public static readonly BinaryOperation Multiplication = new BinaryOperation(nameof(Multiplication), (x1, x2) => x1 * x2);
		public static readonly BinaryOperation Division = new BinaryOperation(nameof(Division), (x1, x2) => x1 / x2);
	}
}

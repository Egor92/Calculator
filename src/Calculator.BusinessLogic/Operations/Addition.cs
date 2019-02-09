﻿namespace Calculator.BusinessLogic.Operations
{
	public class Addition : IBinaryOperation
	{
		public ExecutableInfo GetExecutableInfo(double value1, double value2)
		{
			return ExecutableInfo.CreateExecutable();
		}

		public double Execute(double value1, double value2)
		{
			return value1 + value2;
		}
	}
}
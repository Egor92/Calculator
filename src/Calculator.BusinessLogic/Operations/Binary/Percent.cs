﻿namespace Calculator.BusinessLogic.Operations.Binary
{
    public class Percent : IBinaryOperation
    {
        public ExecutableInfo GetExecutableInfo(double value1, double value2)
        {
            return ExecutableInfo.CreateExecutable();
        }

        public double Execute(double value1, double value2)
        {
            return value1 * value2 / 100;
        }
    }
}

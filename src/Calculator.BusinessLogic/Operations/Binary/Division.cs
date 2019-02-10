using Calculator.BusinessLogic.Constants;

namespace Calculator.BusinessLogic.Operations.Binary
{
    public class Division : IBinaryOperation
    {
        public ExecutableInfo GetExecutableInfo(double value1, double value2)
        {
            if (value2 == 0.0)
            {
                return ExecutableInfo.CreateNotExecutable(ErrorMessages.DivisionOnZero);
            }

            return ExecutableInfo.CreateExecutable();
        }

        public double Execute(double value1, double value2)
        {
            return value1 / value2;
        }
    }
}

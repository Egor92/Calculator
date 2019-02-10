namespace Calculator.BusinessLogic.Operations.Unary
{
    public class Squaring : IUnaryOperation
    {
        public ExecutableInfo GetExecutableInfo(double value)
        {
            return ExecutableInfo.CreateExecutable();
        }

        public double Execute(double value)
        {
            return value * value;
        }
    }
}

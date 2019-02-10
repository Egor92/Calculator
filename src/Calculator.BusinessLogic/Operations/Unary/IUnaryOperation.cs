namespace Calculator.BusinessLogic.Operations.Unary
{
    public interface IUnaryOperation
    {
        ExecutableInfo GetExecutableInfo(double value);

        double Execute(double value);
    }
}

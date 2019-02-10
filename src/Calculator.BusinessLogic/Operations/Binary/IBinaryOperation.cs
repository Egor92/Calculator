namespace Calculator.BusinessLogic.Operations.Binary
{
    public interface IBinaryOperation
    {
        ExecutableInfo GetExecutableInfo(double value1, double value2);

        double Execute(double value1, double value2);
    }
}

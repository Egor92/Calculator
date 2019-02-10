namespace Calculator.BusinessLogic.Operations.Binary
{
    public class BinaryOperationInfo
    {
        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public IBinaryOperation BinaryOperation { get; set; }
    }
}

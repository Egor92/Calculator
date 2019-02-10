namespace Calculator.BusinessLogic.Operations.Binary
{
    public static class BinaryOperations
    {
        public static readonly Addition Addition = new Addition();
        public static readonly Subtraction Subtraction = new Subtraction();
        public static readonly Multiplication Multiplication = new Multiplication();
        public static readonly Division Division = new Division();
        public static readonly Percent Percent = new Percent();
    }
}

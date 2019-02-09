namespace Calculator.BusinessLogic.Operations
{
	public static class Operations
	{
		public static readonly IBinaryOperation Addition = new Addition();
		public static readonly IBinaryOperation Subtraction = new Subtraction();
		public static readonly IBinaryOperation Multiplication = new Multiplication();
		public static readonly IBinaryOperation Division = new Division();
	}
}

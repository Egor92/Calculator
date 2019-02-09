namespace Calculator.BusinessLogic.Operations
{
    public class ExecutableInfo
    {
        private ExecutableInfo(bool canBeExecuted, string message)
        {
            CanBeExecuted = canBeExecuted;
            Message = message;
        }

        public bool CanBeExecuted { get; }

        public string Message { get; }

        public static ExecutableInfo CreateExecutable()
        {
            return new ExecutableInfo(true, null);
        }

        public static ExecutableInfo CreateNotExecutable(string message)
        {
            return new ExecutableInfo(false, message);
        }
    }
}

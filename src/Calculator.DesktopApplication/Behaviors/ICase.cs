namespace Calculator.DesktopApplication.Behaviors
{
    public interface ICase<in TArg, out TResult>
    {
        bool IsMatched(TArg arg);

        TResult Result { get; }
    }
}

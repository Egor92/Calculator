namespace Calculator.Wpf.Common.Behaviors
{
    public interface ICase<in TArg, out TResult>
    {
        bool IsMatched(TArg arg);

        TResult Result { get; }
    }
}

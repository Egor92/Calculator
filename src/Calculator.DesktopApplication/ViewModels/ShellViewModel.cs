using ReactiveUI;

namespace Calculator.DesktopApplication.ViewModels
{
    public class ShellViewModel : ReactiveObject
    {
        #region Fields

        private readonly IMessageBus _messageBus;

        #endregion

        #region Ctor

        public ShellViewModel(IMessageBus messageBus, CalculatorViewModel calculatorVM)
        {
            CalculatorVM = calculatorVM;
            _messageBus = messageBus;
        }

        #endregion

        #region Properties

        #region CalculatorVM

        public CalculatorViewModel CalculatorVM { get; }

        #endregion

        #endregion
    }
}

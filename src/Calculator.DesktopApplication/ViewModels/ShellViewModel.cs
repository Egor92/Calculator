using ReactiveUI;

namespace Calculator.DesktopApplication.ViewModels
{
    public class ShellViewModel : ReactiveObject
    {
        #region Fields

        private readonly IMessageBus _messageBus;

        #endregion

        #region Ctor

        public ShellViewModel(IMessageBus messageBus, StandardCalculatorViewModel standardCalculatorVM, NarrowCalculatorViewModel narrowCalculatorVM)
        {
            StandardCalculatorVM = standardCalculatorVM;
            NarrowCalculatorVM = narrowCalculatorVM;
            _messageBus = messageBus;
        }

        #endregion

        #region Properties

        #region StandardCalculatorVM

        public StandardCalculatorViewModel StandardCalculatorVM { get; }

        #endregion

        #region StandardCalculatorVM

        public NarrowCalculatorViewModel NarrowCalculatorVM { get; }

        #endregion

        #endregion
    }
}

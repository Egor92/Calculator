using System.Diagnostics.CodeAnalysis;
using ReactiveUI;

namespace Calculator.DesktopApplication.ViewModels
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ShellViewModel : ReactiveObject
    {
        #region Fields

        private readonly IMessageBus _messageBus;

        #endregion

        #region Ctor

        public ShellViewModel(IMessageBus messageBus,
                              StandardCalculatorViewModel standardCalculatorVM,
                              NarrowCalculatorViewModel narrowCalculatorVM,
                              TelephoneCalculatorViewModel telephoneCalculatorVM)
        {
            StandardCalculatorVM = standardCalculatorVM;
            NarrowCalculatorVM = narrowCalculatorVM;
            TelephoneCalculatorVM = telephoneCalculatorVM;
            _messageBus = messageBus;
        }

        #endregion

        #region Properties

        #region StandardCalculatorVM

        public StandardCalculatorViewModel StandardCalculatorVM { get; }

        #endregion

        #region NarrowCalculatorViewModel

        public NarrowCalculatorViewModel NarrowCalculatorVM { get; }

        #endregion

        #region TelephoneCalculatorView

        public TelephoneCalculatorViewModel TelephoneCalculatorVM { get; }

        #endregion

        #endregion
    }
}

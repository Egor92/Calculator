using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;
using Calculator.DesktopApplication.Constants;
using Prism.Commands;
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

        #region Commands

        #region ChooseView1Command

        private ICommand _chooseView1Command;

        public ICommand ChooseView1Command
        {
            get { return _chooseView1Command ?? (_chooseView1Command = new DelegateCommand(ChooseView1)); }
        }

        private void ChooseView1()
        {
            _messageBus.SendMessage(new Size(322, 508), AppEvents.SizeChangingRequested);
        }

        #endregion

        #region ChooseView2Command

        private ICommand _chooseView2Command;

        public ICommand ChooseView2Command
        {
            get { return _chooseView2Command ?? (_chooseView2Command = new DelegateCommand(ChooseView2)); }
        }

        private void ChooseView2()
        {
            _messageBus.SendMessage(new Size(500, 300), AppEvents.SizeChangingRequested);
        }

        #endregion

        #region ChooseView3Command

        private ICommand _chooseView3Command;

        public ICommand ChooseView3Command
        {
            get { return _chooseView3Command ?? (_chooseView3Command = new DelegateCommand(ChooseView3)); }
        }

        private void ChooseView3()
        {
            _messageBus.SendMessage(new Size(600, 600), AppEvents.SizeChangingRequested);
        }

        #endregion

        #endregion
    }
}

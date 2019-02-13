using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Calculator.DesktopApplication.ViewModels
{
    public class ButtonViewModel : ReactiveObject
    {
        #region Content

        [Reactive]
        public string Content { get; set; }

        #endregion

        #region Command

        [Reactive]
        public ICommand Command { get; set; }

        #endregion

        #region Command

        [Reactive]
        public bool IsNumber { get; set; }

        #endregion
    }
}

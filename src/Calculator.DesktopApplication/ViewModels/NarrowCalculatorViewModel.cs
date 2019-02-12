using System.Collections.Generic;
using Calculator.BusinessLogic;

namespace Calculator.DesktopApplication.ViewModels
{
    public class NarrowCalculatorViewModel : CalculatorViewModel
    {
        #region Ctor

        public NarrowCalculatorViewModel(ICalculator calculator)
            : base(calculator)
        {
        }

        #endregion

        #region ButtonVMs

        public IEnumerable<ButtonViewModel> ButtonVMs
        {
            get
            {
                yield return NumberOneButtonVM;
                yield return NumberTwoButtonVM;
                yield return NumberThreeButtonVM;
                yield return NumberFourButtonVM;
                yield return NumberFiveButtonVM;
                yield return NumberSixButtonVM;
                yield return NumberSevenButtonVM;
                yield return NumberEightButtonVM;
                yield return NumberNineButtonVM;
                yield return NumberZeroButtonVM;

                yield return NegationButtonVM;
                yield return CommaButtonVM;
                yield return AdditionButtonVM;
                yield return SubtractionButtonVM;
                yield return MultiplicationButtonVM;
                yield return DivisionButtonVM;
                yield return EqualityButtonVM;
                yield return ClearButtonVM;
                yield return ClearLastSymbolButtonVM;
                yield return CancelButtonVM;
            }
        }

        #endregion
    }
}

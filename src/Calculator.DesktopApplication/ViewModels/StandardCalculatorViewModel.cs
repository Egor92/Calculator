using System.Collections.Generic;
using Calculator.BusinessLogic;

namespace Calculator.DesktopApplication.ViewModels
{
    public class StandardCalculatorViewModel : CalculatorViewModel
    {
        #region Ctor

        public StandardCalculatorViewModel(ICalculator calculator)
            : base(calculator)
        {
        }

        #endregion

        #region ButtonVMs

        public IEnumerable<ButtonViewModel> ButtonVMs
        {
            get
            {
                yield return PercentButtonVM;
                yield return SquareRootButtonVM;
                yield return SquaringButtonVM;
                yield return TurningOverButtonVM;
                yield return ClearButtonVM;
                yield return CancelButtonVM;
                yield return ClearLastSymbolButtonVM;
                yield return DivisionButtonVM;
                yield return NumberSevenButtonVM;
                yield return NumberEightButtonVM;
                yield return NumberNineButtonVM;
                yield return MultiplicationButtonVM;
                yield return NumberFourButtonVM;
                yield return NumberFiveButtonVM;
                yield return NumberSixButtonVM;
                yield return SubtractionButtonVM;
                yield return NumberOneButtonVM;
                yield return NumberTwoButtonVM;
                yield return NumberThreeButtonVM;
                yield return AdditionButtonVM;
                yield return NegationButtonVM;
                yield return NumberZeroButtonVM;
                yield return CommaButtonVM;
                yield return EqualityButtonVM;
            }
        }

        #endregion
    }
}

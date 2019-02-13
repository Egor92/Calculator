using System.Collections.Generic;
using Calculator.BusinessLogic;

namespace Calculator.DesktopApplication.ViewModels
{
    public class TelephoneCalculatorViewModel : CalculatorViewModel
    {
        #region Ctor

        public TelephoneCalculatorViewModel(ICalculator calculator)
            : base(calculator)
        {
        }

        #endregion

        #region Properties

        #region NumberButtonVMs

        public IEnumerable<ButtonViewModel> NumberButtonVMs
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
            }
        }

        #endregion

        #endregion
    }
}

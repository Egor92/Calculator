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
                yield return null;
                yield return null;
                yield return null;
                yield return NumberZeroButtonVM;
                yield return NumberNineButtonVM;
                yield return NumberEightButtonVM;
                yield return NumberSevenButtonVM;
                yield return NumberSixButtonVM;
                yield return NumberFiveButtonVM;
                yield return NumberFourButtonVM;
                yield return NumberThreeButtonVM;
                yield return NumberTwoButtonVM;
            }
        }

        #endregion

        #endregion
    }
}

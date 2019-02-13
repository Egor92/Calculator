using System;
using System.Reactive.Subjects;
using Calculator.BusinessLogic;

namespace Calculator.DesktopApplication.Views.Design
{
    public class NullCalculator : ICalculator
    {
        #region Implementation of ICalculator

        public string DisplayValue { get; } = "123456789,0";

        public IObservable<string> DisplayValueChanged { get; } = new BehaviorSubject<string>("123456789,0");

        public void ApplyZero()
        {
        }

        public void ApplyOne()
        {
        }

        public void ApplyTwo()
        {
        }

        public void ApplyThree()
        {
        }

        public void ApplyFour()
        {
        }

        public void ApplyFive()
        {
        }

        public void ApplySix()
        {
        }

        public void ApplySeven()
        {
        }

        public void ApplyEight()
        {
        }

        public void ApplyNine()
        {
        }

        public void ApplyAddition()
        {
        }

        public void ApplySubtraction()
        {
        }

        public void ApplyMultiplication()
        {
        }

        public void ApplyDivision()
        {
        }

        public void ApplyPercent()
        {
        }

        public void ApplySquareRoot()
        {
        }

        public void ApplySquaring()
        {
        }

        public void ApplyTurningOver()
        {
        }

        public void Clear()
        {
        }

        public void ClearLastSymbol()
        {
        }

        public void Cancel()
        {
        }

        public void ApplyNegation()
        {
        }

        public void ApplyComma()
        {
        }

        public void ApplyEquality()
        {
        }

        #endregion
    }
}

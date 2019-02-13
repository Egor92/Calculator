using System;
using Calculator.BusinessLogic;
using Calculator.DesktopApplication.Interactions.Notifications;
using DynamicData;
using Prism.Interactivity.InteractionRequest;

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

        #region TurnTelephoneRequest

        public InteractionRequest<TurnTelephoneNotification> TurnTelephoneRequest { get; } = new InteractionRequest<TurnTelephoneNotification>();

        #endregion

        #region NumberButtonVMs

        private ButtonViewModel[] _numberButtonVMs;

        public ButtonViewModel[] NumberButtonVMs
        {
            get { return _numberButtonVMs ?? (_numberButtonVMs = CreateNumberButtonVMs()); }
        }

        private ButtonViewModel[] CreateNumberButtonVMs()
        {
            return new[]
            {
                NumberOneButtonVM,
                null,
                null,
                null,
                NumberZeroButtonVM,
                NumberNineButtonVM,
                NumberEightButtonVM,
                NumberSevenButtonVM,
                NumberSixButtonVM,
                NumberFiveButtonVM,
                NumberFourButtonVM,
                NumberThreeButtonVM,
                NumberTwoButtonVM,
            };
        }

        #endregion

        #endregion

        protected override void OnApplyZero()
        {
            RaiseTelephoneTurning(NumberZeroButtonVM);
        }

        protected override void OnApplyOne()
        {
            RaiseTelephoneTurning(NumberOneButtonVM);
        }

        protected override void OnApplyTwo()
        {
            RaiseTelephoneTurning(NumberTwoButtonVM);
        }

        protected override void OnApplyThree()
        {
            RaiseTelephoneTurning(NumberThreeButtonVM);
        }

        protected override void OnApplyFour()
        {
            RaiseTelephoneTurning(NumberFourButtonVM);
        }

        protected override void OnApplyFive()
        {
            RaiseTelephoneTurning(NumberFiveButtonVM);
        }

        protected override void OnApplySix()
        {
            RaiseTelephoneTurning(NumberSixButtonVM);
        }

        protected override void OnApplySeven()
        {
            RaiseTelephoneTurning(NumberSevenButtonVM);
        }

        protected override void OnApplyEight()
        {
            RaiseTelephoneTurning(NumberEightButtonVM);
        }

        protected override void OnApplyNine()
        {
            RaiseTelephoneTurning(NumberNineButtonVM);
        }

        private void RaiseTelephoneTurning(ButtonViewModel buttonVM)
        {
            var buttonIndex = NumberButtonVMs.IndexOf(buttonVM);
            var count = NumberButtonVMs.Length;
            var index = (count - buttonIndex) % count + 1;
            var turnTelephoneNotification = new TurnTelephoneNotification
            {
                Index = index,
                Angle = 0.5 + index * (2 * Math.PI / count),
            };
            TurnTelephoneRequest.Raise(turnTelephoneNotification);
        }
    }
}

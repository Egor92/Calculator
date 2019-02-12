using System;
using System.Reactive.Disposables;
using Calculator.BusinessLogic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Calculator.DesktopApplication.ViewModels
{
    public abstract class CalculatorViewModel : ReactiveObject, IDisposable
    {
        #region Fields

        private readonly ICalculator _calculator;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        #endregion

        #region Ctor

        public CalculatorViewModel(ICalculator calculator)
        {
            _calculator = calculator;
            _disposables.Add(SubscribeToDisplayValueUpdating());
        }

        #endregion

        #region Properties

        #region DisplayValue

        [Reactive]
        public string DisplayValue { get; private set; }

        private IDisposable SubscribeToDisplayValueUpdating()
        {
            return _calculator.DisplayValueChanged.Subscribe(displayValue =>
            {
                DisplayValue = displayValue;
            });
        }

        #endregion

        #region NumberZeroButtonVM

        private ButtonViewModel _numberZeroButtonVM;

        public ButtonViewModel NumberZeroButtonVM
        {
            get { return _numberZeroButtonVM ?? (_numberZeroButtonVM = CreateNumberZeroButtonVM()); }
        }

        private ButtonViewModel CreateNumberZeroButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "0",
                Command = ReactiveCommand.Create(ApplyZero),
            };

            void ApplyZero()
            {
                _calculator.ApplyZero();
            }
        }

        #endregion

        #region NumberOneButtonVM

        private ButtonViewModel _numberOneButtonVM;

        public ButtonViewModel NumberOneButtonVM
        {
            get { return _numberOneButtonVM ?? (_numberOneButtonVM = CreateNumberOneButtonVM()); }
        }

        private ButtonViewModel CreateNumberOneButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "1",
                Command = ReactiveCommand.Create(ApplyOne),
            };

            void ApplyOne()
            {
                _calculator.ApplyOne();
            }
        }

        #endregion

        #region NumberTwoButtonVM

        private ButtonViewModel _numberTwoButtonVM;

        public ButtonViewModel NumberTwoButtonVM
        {
            get { return _numberTwoButtonVM ?? (_numberTwoButtonVM = CreateNumberTwoButtonVM()); }
        }

        private ButtonViewModel CreateNumberTwoButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "2",
                Command = ReactiveCommand.Create(ApplyTwo),
            };

            void ApplyTwo()
            {
                _calculator.ApplyTwo();
            }
        }

        #endregion

        #region NumberThreeButtonVM

        private ButtonViewModel _numberThreeButtonVM;

        public ButtonViewModel NumberThreeButtonVM
        {
            get { return _numberThreeButtonVM ?? (_numberThreeButtonVM = CreateNumberThreeButtonVM()); }
        }

        private ButtonViewModel CreateNumberThreeButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "3",
                Command = ReactiveCommand.Create(ApplyThree),
            };

            void ApplyThree()
            {
                _calculator.ApplyThree();
            }
        }

        #endregion

        #region NumberFourButtonVM

        private ButtonViewModel _numberFourButtonVM;

        public ButtonViewModel NumberFourButtonVM
        {
            get { return _numberFourButtonVM ?? (_numberFourButtonVM = CreateNumberFourButtonVM()); }
        }

        private ButtonViewModel CreateNumberFourButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "4",
                Command = ReactiveCommand.Create(ApplyFour),
            };

            void ApplyFour()
            {
                _calculator.ApplyFour();
            }
        }

        #endregion

        #region NumberFiveButtonVM

        private ButtonViewModel _numberFiveButtonVM;

        public ButtonViewModel NumberFiveButtonVM
        {
            get { return _numberFiveButtonVM ?? (_numberFiveButtonVM = CreateNumberFiveButtonVM()); }
        }

        private ButtonViewModel CreateNumberFiveButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "5",
                Command = ReactiveCommand.Create(ApplyFive),
            };

            void ApplyFive()
            {
                _calculator.ApplyFive();
            }
        }

        #endregion

        #region NumberSixButtonVM

        private ButtonViewModel _numberSixButtonVM;

        public ButtonViewModel NumberSixButtonVM
        {
            get { return _numberSixButtonVM ?? (_numberSixButtonVM = CreateNumberSixButtonVM()); }
        }

        private ButtonViewModel CreateNumberSixButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "6",
                Command = ReactiveCommand.Create(ApplySix),
            };

            void ApplySix()
            {
                _calculator.ApplySix();
            }
        }

        #endregion

        #region NumberSevenButtonVM

        private ButtonViewModel _numberSevenButtonVM;

        public ButtonViewModel NumberSevenButtonVM
        {
            get { return _numberSevenButtonVM ?? (_numberSevenButtonVM = CreateNumberSevenButtonVM()); }
        }

        private ButtonViewModel CreateNumberSevenButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "7",
                Command = ReactiveCommand.Create(ApplySeven),
            };

            void ApplySeven()
            {
                _calculator.ApplySeven();
            }
        }

        #endregion

        #region NumberEightButtonVM

        private ButtonViewModel _numberEightButtonVM;

        public ButtonViewModel NumberEightButtonVM
        {
            get { return _numberEightButtonVM ?? (_numberEightButtonVM = CreateNumberEightButtonVM()); }
        }

        private ButtonViewModel CreateNumberEightButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "8",
                Command = ReactiveCommand.Create(ApplyEight),
            };

            void ApplyEight()
            {
                _calculator.ApplyEight();
            }
        }

        #endregion

        #region NumberNineButtonVM

        private ButtonViewModel _numberNineButtonVM;

        public ButtonViewModel NumberNineButtonVM
        {
            get { return _numberNineButtonVM ?? (_numberNineButtonVM = CreateNumberNineButtonVM()); }
        }

        private ButtonViewModel CreateNumberNineButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "9",
                Command = ReactiveCommand.Create(ApplyNine),
            };

            void ApplyNine()
            {
                _calculator.ApplyNine();
            }
        }

        #endregion

        #region CommaButtonVM

        private ButtonViewModel _commaButtonVM;

        public ButtonViewModel CommaButtonVM
        {
            get { return _commaButtonVM ?? (_commaButtonVM = CreateCommaButtonVM()); }
        }

        private ButtonViewModel CreateCommaButtonVM()
        {
            return new ButtonViewModel
            {
                Content = ",",
                Command = ReactiveCommand.Create(ApplyComma),
            };

            void ApplyComma()
            {
                _calculator.ApplyComma();
            }
        }

        #endregion

        #region NegationButtonVM

        private ButtonViewModel _negationButtonVM;

        public ButtonViewModel NegationButtonVM
        {
            get { return _negationButtonVM ?? (_negationButtonVM = CreateNegationButtonVM()); }
        }

        private ButtonViewModel CreateNegationButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "±",
                Command = ReactiveCommand.Create(ApplyNegation),
            };

            void ApplyNegation()
            {
                _calculator.ApplyNegation();
            }
        }

        #endregion

        #region AdditionButtonVM

        private ButtonViewModel _additionButtonVM;

        public ButtonViewModel AdditionButtonVM
        {
            get { return _additionButtonVM ?? (_additionButtonVM = CreateAdditionButtonVM()); }
        }

        private ButtonViewModel CreateAdditionButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "+",
                Command = ReactiveCommand.Create(ApplyAddition),
            };

            void ApplyAddition()
            {
                _calculator.ApplyAddition();
            }
        }

        #endregion

        #region SubtractionButtonVM

        private ButtonViewModel _subtractionButtonVM;

        public ButtonViewModel SubtractionButtonVM
        {
            get { return _subtractionButtonVM ?? (_subtractionButtonVM = CreateSubtractionButtonVM()); }
        }

        private ButtonViewModel CreateSubtractionButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "-",
                Command = ReactiveCommand.Create(ApplySubtraction),
            };

            void ApplySubtraction()
            {
                _calculator.ApplySubtraction();
            }
        }

        #endregion

        #region MultiplicationButtonVM

        private ButtonViewModel _multiplicationButtonVM;

        public ButtonViewModel MultiplicationButtonVM
        {
            get { return _multiplicationButtonVM ?? (_multiplicationButtonVM = CreateMultiplicationButtonVM()); }
        }

        private ButtonViewModel CreateMultiplicationButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "×",
                Command = ReactiveCommand.Create(ApplyMultiplication),
            };

            void ApplyMultiplication()
            {
                _calculator.ApplyMultiplication();
            }
        }

        #endregion

        #region DivisionButtonVM

        private ButtonViewModel _divisionButtonVM;

        public ButtonViewModel DivisionButtonVM
        {
            get { return _divisionButtonVM ?? (_divisionButtonVM = CreateDivisionButtonVM()); }
        }

        private ButtonViewModel CreateDivisionButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "÷",
                Command = ReactiveCommand.Create(ApplyDivision),
            };

            void ApplyDivision()
            {
                _calculator.ApplyDivision();
            }
        }

        #endregion

        #region PercentButtonVM

        private ButtonViewModel _percentButtonVM;

        public ButtonViewModel PercentButtonVM
        {
            get { return _percentButtonVM ?? (_percentButtonVM = CreatePercentButtonVM()); }
        }

        private ButtonViewModel CreatePercentButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "%",
                Command = ReactiveCommand.Create(ApplyPercent),
            };

            void ApplyPercent()
            {
                _calculator.ApplyPercent();
            }
        }

        #endregion

        #region SquareRootButtonVM

        private ButtonViewModel _squareRootButtonVM;

        public ButtonViewModel SquareRootButtonVM
        {
            get { return _squareRootButtonVM ?? (_squareRootButtonVM = CreateSquareRootButtonVM()); }
        }

        private ButtonViewModel CreateSquareRootButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "√",
                Command = ReactiveCommand.Create(ApplySquareRoot),
            };

            void ApplySquareRoot()
            {
                _calculator.ApplySquareRoot();
            }
        }

        #endregion

        #region SquaringButtonVM

        private ButtonViewModel _squaringButtonVM;

        public ButtonViewModel SquaringButtonVM
        {
            get { return _squaringButtonVM ?? (_squaringButtonVM = CreateSquaringButtonVM()); }
        }

        private ButtonViewModel CreateSquaringButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "x²",
                Command = ReactiveCommand.Create(ApplySquaring),
            };

            void ApplySquaring()
            {
                _calculator.ApplySquaring();
            }
        }

        #endregion

        #region TurningOverButtonVM

        private ButtonViewModel _turningOverButtonVM;

        public ButtonViewModel TurningOverButtonVM
        {
            get { return _turningOverButtonVM ?? (_turningOverButtonVM = CreateTurningOverButtonVM()); }
        }

        private ButtonViewModel CreateTurningOverButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "1/x",
                Command = ReactiveCommand.Create(ApplyTurningOver),
            };

            void ApplyTurningOver()
            {
                _calculator.ApplyTurningOver();
            }
        }

        #endregion

        #region EqualityButtonVM

        private ButtonViewModel _equalityButtonVM;

        public ButtonViewModel EqualityButtonVM
        {
            get { return _equalityButtonVM ?? (_equalityButtonVM = CreateEqualityButtonVM()); }
        }

        private ButtonViewModel CreateEqualityButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "=",
                Command = ReactiveCommand.Create(ApplyEquality),
            };

            void ApplyEquality()
            {
                _calculator.ApplyEquality();
            }
        }

        #endregion

        #region ClearButtonVM

        private ButtonViewModel _clearButtonVM;

        public ButtonViewModel ClearButtonVM
        {
            get { return _clearButtonVM ?? (_clearButtonVM = CreateClearButtonVM()); }
        }

        private ButtonViewModel CreateClearButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "CE",
                Command = ReactiveCommand.Create(ApplyClear),
            };

            void ApplyClear()
            {
                _calculator.Clear();
            }
        }

        #endregion

        #region ClearLastSymbolButtonVM

        private ButtonViewModel _clearLastSymbolButtonVM;

        public ButtonViewModel ClearLastSymbolButtonVM
        {
            get { return _clearLastSymbolButtonVM ?? (_clearLastSymbolButtonVM = CreateClearLastSymbolButtonVM()); }
        }

        private ButtonViewModel CreateClearLastSymbolButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "←",
                Command = ReactiveCommand.Create(ApplyClearLastSymbol),
            };

            void ApplyClearLastSymbol()
            {
                _calculator.ClearLastSymbol();
            }
        }

        #endregion

        #region CancelButtonVM

        private ButtonViewModel _cancelButtonVM;

        public ButtonViewModel CancelButtonVM
        {
            get { return _cancelButtonVM ?? (_cancelButtonVM = CreateCancelButtonVM()); }
        }

        private ButtonViewModel CreateCancelButtonVM()
        {
            return new ButtonViewModel
            {
                Content = "C",
                Command = ReactiveCommand.Create(ApplyCancel),
            };

            void ApplyCancel()
            {
                _calculator.Cancel();
            }
        }

        #endregion

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposables?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

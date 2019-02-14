using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Input;
using Calculator.BusinessLogic;
using Calculator.Wpf.Common.AppBehaviors;

namespace Calculator.DesktopApplication.AppBehaviors
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ApplyKeyboardActionsToCalculatorAppBehavior : IAppBehavior
    {
        private readonly Window _window;
        private readonly ICalculator _calculator;

        private static readonly IDictionary<Key, Action<ICalculator>> CalculatorActionsByKey = new Dictionary<Key, Action<ICalculator>>
        {
            [Key.NumPad1] = x => x.ApplyOne(),
            [Key.D1] = x => x.ApplyOne(),
            [Key.NumPad2] = x => x.ApplyTwo(),
            [Key.D2] = x => x.ApplyTwo(),
            [Key.NumPad3] = x => x.ApplyThree(),
            [Key.D3] = x => x.ApplyThree(),
            [Key.NumPad4] = x => x.ApplyFour(),
            [Key.D4] = x => x.ApplyFour(),
            [Key.NumPad5] = x => x.ApplyFive(),
            [Key.D5] = x => x.ApplyFive(),
            [Key.NumPad6] = x => x.ApplySix(),
            [Key.D6] = x => x.ApplySix(),
            [Key.NumPad7] = x => x.ApplySeven(),
            [Key.D7] = x => x.ApplySeven(),
            [Key.NumPad8] = x => x.ApplyEight(),
            [Key.D8] = x => x.ApplyEight(),
            [Key.NumPad9] = x => x.ApplyNine(),
            [Key.D9] = x => x.ApplyNine(),
            [Key.NumPad0] = x => x.ApplyZero(),
            [Key.D0] = x => x.ApplyZero(),
            [Key.OemComma] = x => x.ApplyComma(),
            [Key.Add] = x => x.ApplyAddition(),
            [Key.Subtract] = x => x.ApplySubtraction(),
            [Key.Multiply] = x => x.ApplyMultiplication(),
            [Key.Divide] = x => x.ApplyDivision(),
            [Key.Enter] = x => x.ApplyEquality(),
            [Key.Escape] = x => x.Cancel(),
            [Key.Back] = x => x.ClearLastSymbol(),
        };

        public ApplyKeyboardActionsToCalculatorAppBehavior(Window window, ICalculator calculator)
        {
            _window = window;
            _calculator = calculator;
        }

        public IDisposable Attach()
        {
            _window.KeyDown += OnKeyDown;
            return Disposable.Create(() =>
            {
                _window.KeyDown -= OnKeyDown;
            });
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (CalculatorActionsByKey.TryGetValue(e.Key, out var action))
            {
                action(_calculator);
            }
        }
    }
}

using Calculator.DesktopApplication.ViewModels;

namespace Calculator.DesktopApplication.Views.Design
{
    public static class DesignViewModels
    {
        private static readonly NullCalculator NullCalculator = new NullCalculator();

        public static StandardCalculatorViewModel StandardCalculatorVM { get; } = new StandardCalculatorViewModel(NullCalculator);

        public static NarrowCalculatorViewModel NarrowCalculatorVM { get; } = new NarrowCalculatorViewModel(NullCalculator);

        public static TelephoneCalculatorViewModel TelephoneCalculatorVM { get; } = new TelephoneCalculatorViewModel(NullCalculator);
    }
}

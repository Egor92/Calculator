namespace Calculator.BusinessLogic
{
    public interface ICalculator
    {
        string DisplayValue { get; }

        void ApplyZero();

        void ApplyOne();

        void ApplyTwo();

        void ApplyThree();

        void ApplyFour();

        void ApplyFive();

        void ApplySix();

        void ApplySeven();

        void ApplyEight();

        void ApplyNine();

        void ApplyAddition();

        void ApplySubtraction();

        void ApplyMultiplication();

        void ApplyDivision();

        void ApplyPercent();

        void ApplySquareRoot();

        void ApplySquaring();

        void ApplyTurningOver();

        void Clear();

        void ClearLastSymbol();

        void Cancel();

        void ApplyNegation();

        void ApplyComma();

        void ApplyEquality();
    }
}

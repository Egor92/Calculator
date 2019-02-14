using System.Text;
using Calculator.BusinessLogic.Constants;

namespace Calculator.BusinessLogic
{
    internal class DisplayNumber
    {
        public DisplayNumber()
        {
            Reset();
        }

        public bool IsNegative { get; set; }

        public string IntegerPart { get; set; }

        public bool HasComma { get; set; }

        public string FractionalPart { get; set; }

        public string Exponent { get; set; }

        public bool IsDefault()
        {
            return IsNegative == DisplayNumberDefaults.IsNegative
                && IntegerPart == DisplayNumberDefaults.IntegerPart
                && HasComma == DisplayNumberDefaults.HasComma
                && FractionalPart == DisplayNumberDefaults.FractionalPart;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            if (IsNegative)
            {
                stringBuilder.Append("-");
            }

            stringBuilder.Append(IntegerPart);
            if (HasComma)
            {
                stringBuilder.Append(",");
                stringBuilder.Append(FractionalPart);
            }

            if (!string.IsNullOrEmpty(Exponent))
            {
                stringBuilder.Append("E+");
                stringBuilder.Append(Exponent);
            }

            return stringBuilder.ToString();
        }

        public double ToDouble()
        {
            var stringRepresentation = ToString();
            return double.Parse(stringRepresentation);
        }

        public void Reset()
        {
            IsNegative = DisplayNumberDefaults.IsNegative;
            IntegerPart = DisplayNumberDefaults.IntegerPart;
            HasComma = DisplayNumberDefaults.HasComma;
            FractionalPart = DisplayNumberDefaults.FractionalPart;
            Exponent = DisplayNumberDefaults.Exponent;
        }
    }

    internal static class DisplayNumberExtensions
    {
        public static void ClearLastSymbol(this DisplayNumber displayNumber)
        {
            if (displayNumber.HasComma)
            {
                if (!string.IsNullOrEmpty(displayNumber.FractionalPart))
                {
                    displayNumber.FractionalPart = displayNumber.FractionalPart.Substring(0, displayNumber.FractionalPart.Length - 1);
                }
                else
                {
                    displayNumber.HasComma = false;
                }
            }
            else
            {
                var integerPartLength = displayNumber.IntegerPart.Length;
                if (integerPartLength > 1)
                {
                    displayNumber.IntegerPart = displayNumber.IntegerPart.Substring(0, integerPartLength - 1);
                }
                else
                {
                    displayNumber.Reset();
                }
            }
        }
    }
}

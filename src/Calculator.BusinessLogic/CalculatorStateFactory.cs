using System;
using System.Text.RegularExpressions;

namespace Calculator.BusinessLogic
{
    internal static class DisplayNumberFactory
    {
        internal static DisplayNumber Create(string displayValue)
        {
            if (displayValue == null)
            {
                throw new ArgumentNullException(nameof(displayValue));
            }

            var match = Regex.Match(displayValue, @"(-?)(\d+)(,?)(\d*)(E([\+\-]\d+))?");
            bool isNegative = GetValue(match, 1) == "-";
            string integerPart = GetValue(match, 2);
            bool hasComma = GetValue(match, 3) == ",";
            string fractionalPart = GetValue(match, 4);
            string exponent = GetValue(match, 6);

            return new DisplayNumber
            {
                IsNegative = isNegative,
                IntegerPart = integerPart,
                HasComma = hasComma,
                FractionalPart = fractionalPart,
                Exponent = exponent,
            };
        }

        private static string GetValue(Match match, int index)
        {
            var group = match.Groups[index];
            return group.Value;
        }
    }
}

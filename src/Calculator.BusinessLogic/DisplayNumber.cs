using System.Text;
using Calculator.BusinessLogic.Constants;

namespace Calculator.BusinessLogic
{
	internal class DisplayNumber
	{
		public DisplayNumber()
		{
			IsNegative = DisplayNumberDefaults.IsNegative;
			IntegerPart = DisplayNumberDefaults.IntegerPart;
			HasComma = DisplayNumberDefaults.HasComma;
			FractionalPart = DisplayNumberDefaults.FractionalPart;
		}

		public bool IsNegative { get; set; }

		public string IntegerPart { get; set; }

		public bool HasComma { get; set; }

		public string FractionalPart { get; set; }

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

			return stringBuilder.ToString();
		}
	}
}

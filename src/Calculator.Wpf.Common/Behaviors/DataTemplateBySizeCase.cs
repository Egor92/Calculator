using System;
using System.Windows;
using System.Windows.Markup;

namespace Calculator.Wpf.Common.Behaviors
{
    [ContentProperty(nameof(Result))]
    public class DataTemplateBySizeCase : ICase<Size, DataTemplate>
    {
        public bool IsMatched(Size size)
        {
            if (HeightMin != null && size.Height < HeightMin.Value)
                return false;

            if (HeightMax != null && size.Height > HeightMax.Value)
                return false;

            if (WidthMin != null && size.Width < WidthMin.Value)
                return false;

            if (WidthMax != null && size.Width > WidthMax.Value)
                return false;

            var heightToWidthRatio = Math.Log(size.Height / size.Width, 2);
            if (HeightToWidthRatioMin != null && heightToWidthRatio < HeightToWidthRatioMin.Value)
                return false;

            if (HeightToWidthRatioMax != null && heightToWidthRatio > HeightToWidthRatioMax.Value)
                return false;

            return true;
        }

        public DataTemplate Result { get; set; }

        public double? HeightMin { get; set; }

        public double? HeightMax { get; set; }

        public double? WidthMin { get; set; }

        public double? WidthMax { get; set; }

        public double? HeightToWidthRatioMin { get; set; }

        public double? HeightToWidthRatioMax { get; set; }
    }
}

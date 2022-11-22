using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace Vistas
{
    public class ConversorDeEstados : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String sEstado = (String)value;

            if (value != null)
            {
                switch (sEstado)
                {
                    case "PENDIENTE":
                        ///return new SolidColorBrush(Colors.Red)
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000");

                    case "PAGADA":
                        ///return new SolidColorBrush(Colors.Green)
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#228B22");

                    case "CONTABILIZADA":
                        ///return new SolidColorBrush(Colors.Blue)
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#4169E1");

                    case "ANULADA":
                        ///return new SolidColorBrush(Colors.Silver)
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#B7C4CF");

                    default:
                        return new SolidColorBrush(Colors.Transparent);

                }
            }
            return Binding.DoNothing;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

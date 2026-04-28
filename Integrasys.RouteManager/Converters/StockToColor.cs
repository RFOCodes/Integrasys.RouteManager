using System.Globalization;

namespace Integrasys.RouteManager.Converters;

public class StockToColor : IValueConverter
{
   public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
   {
      return value is int stock and < 0 ? Colors.Red : Colors.Blue;
   }

   public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
   {
      return null;
   }
}
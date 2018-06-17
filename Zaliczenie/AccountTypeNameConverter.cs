using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AccountManager
{
	/// <summary>
	/// Konwertuje wartości typu AccountType do reprezentacji tekstowej
	/// przyjaznej użytkownikowi typu sting.
	/// </summary>
	class AccountTypeNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return AccountTypeName.AccountTypes[(AccountType)value];
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

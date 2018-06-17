using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    class AccountTypeName
    {
		// Mapujemy typy kont do nazw które będą wyświetlane
		public static Dictionary<AccountType, string> AccountTypes { get; } = new Dictionary<AccountType, string>
			{
				{ AccountType.PersonalAccount, "Rachunek oszczędnościowo-rozliczeniowy" },
				{ AccountType.DepositAccount, "Lokata" },
				{ AccountType.CreditCard, "Karta kredytowa" }
			};

	}
}

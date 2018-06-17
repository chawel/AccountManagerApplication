using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    public class DepositAccount : Account
	{
		public DepositAccount(int identificationNumber) : base(AccountType.DepositAccount, identificationNumber) { }

		public override void DepositMoney(decimal cashAmount)
		{
			// Jeżeli na lokacie znajdują już się pieniądze
			// to nie możemy dodać kolejnej wpłaty
			if (Balance > 0) return;

			// W innym przypadku dokonujemy pierwszej wpłaty
			Balance += cashAmount;
		}

		public override void WithdrawMoney(decimal cashAmount)
		{
			// Ustalamy, że nie można pobrać pieniędzy z lokaty
			return;
		}
    }
}

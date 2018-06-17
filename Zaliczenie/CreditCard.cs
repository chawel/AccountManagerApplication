using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
	public class CreditCard : Account
	{
		public CreditCard(int identificationNumber) : base(AccountType.CreditCard, identificationNumber) { }

		public override void DepositMoney(decimal cashAmount)
		{
			// Nie możemy dokonać wpłaty większej niż wysokość
			// zaciągniętego kredytu
			// Math.Abs zwróci wartość absolutną (bez minusa) balansu konta
			if (cashAmount > Math.Abs(Balance)) return;

			// W innym przypadku dokonujemy pierwszej wpłaty
			Balance += cashAmount;
		}

		public override void WithdrawMoney(decimal cashAmount)
		{
			// Ustalamy, że można pobierać bez ograniczeń pieniądze z karty kredytowej
			Balance -= cashAmount;
		}
	}
}

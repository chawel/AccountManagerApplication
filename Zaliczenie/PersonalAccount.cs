using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
	public class PersonalAccount : Account
	{
		public PersonalAccount(int identificationNumber) : base(AccountType.PersonalAccount, identificationNumber) { }

		public override void DepositMoney(decimal cashAmount)
		{
			// Istotne jest umiejsowienie '+', oznacza że tyle co
			// Balance = Balance + cashAmount
			Balance += cashAmount;
		}

		public override void WithdrawMoney(decimal cashAmount)
		{
			// Ustalamy, że nie można pobrać więcej niż jest na koncie
			if (Balance >= cashAmount) Balance -= cashAmount;
		}
	}
}

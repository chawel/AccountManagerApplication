using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    public class Client
    {
		public string Surname { get; set; }
		public HashSet<Account> Accounts { get; protected set; }

		public Client(string surname)
		{
			this.Surname = surname;
			this.Accounts = new HashSet<Account>();
		}

		public bool AddAccount(Account account)
		{
			return Accounts.Add(account);
		}

		public bool DeleteAccount(Account account)
		{
			return Accounts.Remove(account);
		}

		//public override string ToString()
		//{
		//	return Surname;
		//}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager
{
    public class AccountNumber
    {
		private static int AccountCounter = 0;

		public static int GenerateAccountNumber()
		{
			// Thread-safe inkrementacja
			return Interlocked.Increment(ref AccountCounter);
		}

	}
}

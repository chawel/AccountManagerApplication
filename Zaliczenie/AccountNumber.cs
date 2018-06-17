using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager
{
	/// <summary>
	/// Generuje unikalny numer konta 
	/// </summary>
    public class AccountNumberGenerator
    {
		private static int AccountCounter = 0;

		public static int Generate()
		{
			// Thread-safe inkrementacja
			return Interlocked.Increment(ref AccountCounter);
		}

	}
}

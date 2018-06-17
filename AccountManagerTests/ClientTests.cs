using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Tests
{
	[TestClass()]
	public class ClientTests
	{
		[TestMethod()]
		public void AddAccount_WhenAccountAdded_ReturnsTrue_Test()
		{
			var client = new Client("testClient");
			var newAccount = new PersonalAccount(1);
			var resultOfAdd = client.AddAccount(newAccount);
			Assert.IsTrue(resultOfAdd);
		}

		[TestMethod()]
		public void AddAccount_WhenDuplicateAccountAdded_ReturnsFalse_Test()
		{
			var client = new Client("testClient");
			var newAccount = new PersonalAccount(1);
			var resultOfFirstAdd = client.AddAccount(newAccount);
			var resultOfSecondAdd = client.AddAccount(newAccount);
			Assert.IsFalse(resultOfSecondAdd);
		}

		[TestMethod()]
		public void AddAccount_AddsAccountToClient_Test()
		{
			var client = new Client("testClient");
			var newAccount = new PersonalAccount(1);
			client.AddAccount(newAccount);
			Assert.IsTrue(client.Accounts.Contains(newAccount));
		}

		[TestMethod()]
		public void DeleteAccountTest()
		{
			var client = new Client("testClient");
			var newAccount = new PersonalAccount(1);
			client.AddAccount(newAccount);
			client.DeleteAccount(newAccount);
			Assert.IsFalse(client.Accounts.Contains(newAccount));
		}
	}
}
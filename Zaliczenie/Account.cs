using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager
{
	/// <summary>
	/// Zbiór rodzajów kont
	/// </summary>
	public enum AccountType
	{
		PersonalAccount,
		DepositAccount,
		CreditCard
	}

	// Dziedziczymy interfejs IEquatable aby spełnić kontrakt
	// i napisać własną implementację metody Equals
	// Przyda się to do porównywania obiektów po IdentificationNumber
	// w HashSet (aby spróbować zachować unikalność kont)
	public abstract class Account : IEquatable<Account>
	{
		#region Properties
		// Deklarujemy prywatne pola klasy (będą niemutowalne)
		// Dzięki tym konstrukcjom możemy przypisywać wartości
		// jedynie z wnętrza klasy pochodnej
		// ale możemy odczytywać wartości "za zewnątrz"

		// Końcówka "m" jako oznaczenie liczby typu decimal
		// (prawdopodobnie od słowa 'money', ale możliwe że tylko
		// dlatego, że "d" było już zajęte przez typ double)
		// inne: 
		// "d" - double
		// "f" - float
		public decimal Balance { get; protected set; } = 0.00m;
		public AccountType AccountType { get; protected set; }
		public int IdentificationNumber { get; protected set; }
		#endregion

		#region Konstruktor
		public Account(AccountType accountType, int identificationNumber)
		{
			this.IdentificationNumber = identificationNumber;
			this.AccountType = accountType;
		}
		#endregion

		#region Kontrakt
		// Deklarujemy kontrakty na metody
		// kontrakt oznacza że musimy takie same metody
		// zaimplementować w naszej klasie pochodnej
		// inaczej kompilator nie zbuduje projektu
		public abstract void DepositMoney(decimal moneyAmount);
		public abstract void WithdrawMoney(decimal moneyAmount);
		#endregion

		public override string ToString()
		{
			return String.Format("Account type: {0} Account number: {1} Balance: {2}",
				AccountTypeName.AccountTypes[this.AccountType], 
				this.IdentificationNumber.ToString(), 
				this.Balance.ToString());
		}

		// Spełniamy kontrakt interfejsu IEquatable, czyli wymagającego metody implementującej
		// sposób porównywania obiektów (w tym przypadku klasy Account i dziedziczących po niej)
		// Porównujemy po IdentyfiactionNumber, który ma być unikalny dla każdej instancji
		public bool Equals(Account other)
		{
			// sprawdzamy czy nie porównujemy do pustego obiektu - null
			// w takich wypadkach metoda Equals zawsze musi zwrócić false
			if (other == null) return false;
			// Sprawdzamy czy IdentificationNumber jest taki sam jak obiektu do którego porównujemy (bool)
			return this.IdentificationNumber.Equals(other.IdentificationNumber);
		}

		// Nadpisujemy metodę GetHashCode, która używana jest np. w obiektach typu HashSet
		// są one "kontenerami" dla unikalnych obiektów.
		// HashSet decyduje o unikalności porównując HashCode obiektów,
		// dlatego musimy zaimplementować na podstawie czego generowany jest HashCode.
		// W tym przypadku, logika Equals i GetHashCode powinna być taka sama, czyli
		// unikalność determinuje IdentificationNumber.
		// Należy pamiętać. aby pole które wykorzystujemy do generowania HashCode było
		// niemutowalne - to znaczy aby nie mogło się zmieniać w trakcie działania
		// programu, zapewni to poprawność HashCode.
		public override int GetHashCode()
		{
			// Obliczamy HashCode dla unikalnego numeru indentyfikacyjnego
			return this.IdentificationNumber.GetHashCode();
		}
	}
}

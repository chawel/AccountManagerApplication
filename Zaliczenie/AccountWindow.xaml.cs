using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountManager
{
	/// <summary>
	/// Interaction logic for AccountWindow.xaml
	/// </summary>
	public partial class AccountWindow : Window
	{
		// Ważne aby dodać getter i setter
		public int UniqueAccountNumber { get; set; }

		public AccountWindow()
		{
			// Generujemy za każdym otwarciem okna nowy unikalny numer konta
			UniqueAccountNumber = AccountNumber.GenerateAccountNumber();

			InitializeComponent();

			// Ustawiamy tekst kontrolki
			AccountNumberTextBox.Text = UniqueAccountNumber.ToString();

			// Boże wybacz...
			AccountTypeListCombo.ItemsSource =  AccountTypeName.AccountTypes;

			// Ustawiamy contekst dla tego okna na to okno 
			// (bez sensu ale trzeba, aby można było bindować dane do kontrolek)
			DataContext = this;
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}

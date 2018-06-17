using System;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Ze względu na treść zadania musimy kilka rzeczy zrobić
		// trochę "bez sensu" (np. musimy znać unikalne ID zanim w ogóle stworzymy konto)
		// dlatego zadeklarujemy tutaj kilka rzeczy do obsługi kont i klientów
		private ObservableCollection<Client> Clients;

		public MainWindow()
		{
			Clients = new ObservableCollection<Client>();

			InitializeComponent();

			// ObservableCollection sam będzie dbał o
			// aktualizację widoku Comboboxa
			// za sprawą INotifyPropertyChanged 
			CustomerListCombo.ItemsSource = Clients;

			// Lokacja gdzie pojwi się główne okno ustawione na środek ekranu
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			
			DataContext = this;
		}

		private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
		{
			// Aby okno pojawiło się centrum okna rodzica (czyli MainWindow)
			// this == MainWindow
			var customerWindow = new CustomerWindow { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };

			if (customerWindow.ShowDialog() == true)
			{
				var customer = new Client(customerWindow.SurnameTextBox.Text);
				Clients.Add(customer);
				CustomerListCombo.SelectedItem = customer;
			}
		}

		private void AddAccountButton_Click(object sender, RoutedEventArgs e)
		{
			var accountWindow = new AccountWindow { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
			var selectedClient = (Client)CustomerListCombo.SelectedItem;

			if (accountWindow.ShowDialog() == true)
			{
				AccountType accountType = (AccountType)accountWindow.AccountTypeListCombo.SelectedValue;
				Account account;

				switch (accountType)
				{
					case AccountType.PersonalAccount:
						account = new PersonalAccount(accountWindow.UniqueAccountNumber);
						break;
					case AccountType.DepositAccount:
						account = new DepositAccount(accountWindow.UniqueAccountNumber);
						break;
					case AccountType.CreditCard:
						account = new CreditCard(accountWindow.UniqueAccountNumber);
						break;
					default:
						account = new PersonalAccount(accountWindow.UniqueAccountNumber);
						break;
				}
				selectedClient.AddAccount(account);
			}

			// Będzie tego sporo, kolekcja kont jest w HashSet
			// a ten nie obsługuje INotifyPropertyChanged 
			// więc nie można bezpośrednio śledzić czy zbiór się zmienił
			// dlatego z braku innego pomysłu, po prostu odświeżam widok za każdym
			// razem kiedy potencjalnie mogło coś się zmienić
			CustomerAccountListView.Items.Refresh();
		}

		private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedClient = (Client)CustomerListCombo.SelectedItem;
			var selectedAccount = (Account)CustomerAccountListView.SelectedItem;

			if (selectedAccount == null)
			{
				MessageBox.Show("Musisz wybrać konto które chcesz usunąć!", "Wybierz konto", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (MessageBox.Show("Na pewno usunąć konto?", "Usuń konto", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
			{
				selectedClient.DeleteAccount(selectedAccount);
			}

			CustomerAccountListView.Items.Refresh();
		}

		private void CustomerListCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedClient = (Client)CustomerListCombo.SelectedItem;
			CustomerAccountListView.ItemsSource = selectedClient.Accounts;

			if (selectedClient != null)
			{
				AddAccountButton.IsEnabled = true;
				DeleteAccountButton.IsEnabled = true;
			}

			CustomerAccountListView.Items.Refresh();
		}

		private void DepositButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedAccount = (Account)CustomerAccountListView.SelectedItem;
			decimal money;

			if (selectedAccount == null)
			{
				MessageBox.Show("Musisz wybrać konto!", "Wybierz konto", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (!decimal.TryParse(AmountTextBox.Text, out money) || AmountTextBox.Text.Contains("-"))
			{
				MessageBox.Show("Wpisz właściwą ilość pieniędzy!", "Zła ilość!", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			selectedAccount.DepositMoney(money);
			CustomerAccountListView.Items.Refresh();
		}

		private void WithdrawButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedAccount = (Account)CustomerAccountListView.SelectedItem;
			decimal money;

			if (selectedAccount == null)
			{
				MessageBox.Show("Musisz wybrać konto!", "Wybierz konto", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (!decimal.TryParse(AmountTextBox.Text, out money) || AmountTextBox.Text.Contains("-"))
			{
				MessageBox.Show("Wpisz właściwą ilość pieniędzy!", "Zła ilość!", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			selectedAccount.WithdrawMoney(money);
			CustomerAccountListView.Items.Refresh();
		}

	}
}

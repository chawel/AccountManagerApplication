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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Lokacja gdzie pojwi się główne okno ustawione na środek ekranu
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
		{
			// Aby okno pojawiło się centrum okna rodzica (czyli MainWindow)
			// this == MainWindow
			var customerWindow = new CustomerWindow { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };

			if (customerWindow.ShowDialog() == true)
			{

			}
		}

		private void AddAccountButton_Click(object sender, RoutedEventArgs e)
		{
			var accountWindow = new AccountWindow { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };

			if (accountWindow.ShowDialog() == true)
			{

			}
		}
	}
}

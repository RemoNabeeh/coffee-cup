using CoffeeCup.Services;
using System.Windows;

namespace CoffeeCup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

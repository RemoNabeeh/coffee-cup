using CoffeeCup.CoffeeTypes;
using CoffeeCup.Customers;
using Unity;

namespace CoffeeCup
{
    class MainWindowViewModel : BindableBase
    {
        private readonly CustomerListViewModel _customerListViewModel;
        private readonly CoffeeTypeListViewModel _coffeeTypeListViewModel;

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
                
            _customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();
            _coffeeTypeListViewModel = ContainerHelper.Container.Resolve<CoffeeTypeListViewModel>();        
        }

        public RelayCommand<string> NavCommand { get; private set; }
        
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "coffeeType":
                    CurrentViewModel = _coffeeTypeListViewModel;
                    break;
                default:
                    CurrentViewModel = _customerListViewModel;
                    break;
            }
        }
    }
}

using CoffeeCup.Data;
using CoffeeCup.Services;
using System.Collections.ObjectModel;

namespace CoffeeCup.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICoffeeTypeRepository _coffeeTypeRepository;

        public CustomerListViewModel(ICustomerRepository customerRepository, ICoffeeTypeRepository coffeeTypeRepository)
        {
            _coffeeTypeRepository = coffeeTypeRepository;
            _customerRepository = customerRepository;

            NewCustomer = new RelayCommand(OnNewCustomer);
            DeleteCustomer = new RelayCommand(OnDeleteCustomer);
            SaveCustomer = new RelayCommand(OnSaveCustomer);
            CancelCustomer = new RelayCommand(OnCancelCustomer);

            EditMode = false;
            EditableCustomer = new EditableCustomer();
        }

        #region [Properties]

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                SetProperty(ref _selectedCustomer, value);
                EditMode = value != null;
                if (value == null)
                {
                    EditableCustomer = null;
                }
                else
                {
                    EditableCustomer = new EditableCustomer()
                    {
                        Id = value.Id,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        FavoriteCoffeeType = value.FavoriteCoffeeType
                    };
                }
            }
        }

        private ObservableCollection<CoffeeType> _coffeeTypes;
        public ObservableCollection<CoffeeType> CoffeeTypes
        {
            get { return _coffeeTypes; }
            set { SetProperty(ref _coffeeTypes, value); }
        }

        private EditableCustomer _editableCustomer;
        public EditableCustomer EditableCustomer
        {
            get { return _editableCustomer; }
            set
            {
                SetProperty(ref _editableCustomer, value);
                if (value != null && value.Id != default)
                {
                    DeleteCustomer.RaiseCanExecuteChanged();
                }
            }
        }

        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        #endregion

        #region [Load Data]

        public async void LoadData()
        {
            LoadCustomers();
            LoadCoffeeTypes();
        }

        private async void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(await _customerRepository.GetCustomersAsync());
        }

        private async void LoadCoffeeTypes()
        {
            CoffeeTypes = new ObservableCollection<CoffeeType>(await _coffeeTypeRepository.GetCoffeeTypesAsync());
        }

        #endregion

        #region [New Command]

        public RelayCommand NewCustomer { get; private set; }

        private void OnNewCustomer()
        {
            EditMode = false;
            SelectedCustomer = null;
            EditableCustomer = new EditableCustomer();
        }

        #endregion

        #region [Delete Command]

        public RelayCommand DeleteCustomer { get; private set; }

        private void OnDeleteCustomer()
        {
            _customerRepository.DeleteCustomerAsync(SelectedCustomer.Id);
            Customers.Remove(SelectedCustomer);
        }

        #endregion

        #region [Save Command]

        public RelayCommand SaveCustomer { get; private set; }

        private void OnSaveCustomer()
        {
            var customer = new Customer()
            {
                Id = EditableCustomer.Id,
                FirstName = EditableCustomer.FirstName,
                LastName = EditableCustomer.LastName,
                FavoriteCoffeeType = EditableCustomer.FavoriteCoffeeType
            };
            if (EditableCustomer.Id == default)
            {
                _customerRepository.AddCustomerAsync(customer);
                Customers.Add(customer);
            }
            else
            {
                _customerRepository.UpdateCustomerAsync(customer);
            }
        }

        #endregion

        #region [Cancel Command]

        public RelayCommand CancelCustomer { get; private set; }

        private void OnCancelCustomer()
        {
            SelectedCustomer = null;
            EditableCustomer = new EditableCustomer();
            EditMode = false;
        }

        #endregion
    }
}

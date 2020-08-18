using System.ComponentModel.DataAnnotations;

namespace CoffeeCup.Customers
{
    public class EditableCustomer : ValidatableBindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _firstName;
        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private short _favoriteCoffeeType;
        [Required]
        public short FavoriteCoffeeType
        {
            get { return _favoriteCoffeeType; }
            set { SetProperty(ref _favoriteCoffeeType, value); }
        }
    }
}

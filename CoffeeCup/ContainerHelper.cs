using CoffeeCup.Services;
using Unity;
using Unity.Lifetime;

namespace CoffeeCup
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<ICustomerRepository, CustomerRepository>(
                new ContainerControlledLifetimeManager());
            _container.RegisterType<ICoffeeTypeRepository, CoffeeTypeRepository>(
                new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}

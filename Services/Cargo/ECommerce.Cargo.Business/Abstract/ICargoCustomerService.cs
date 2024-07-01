using ECommerce.Cargo.Entity.Concrete;

namespace ECommerce.Cargo.Business.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCargoCustomerById(string id);
    }
}

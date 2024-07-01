using ECommerce.Cargo.Entity.Concrete;

namespace ECommerce.Cargo.DataAccess.Abstract
{
    public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
    {
        CargoCustomer GetCargoCustomerById(string id);
    }
}

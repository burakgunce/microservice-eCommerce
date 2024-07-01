using ECommerce.Cargo.DataAccess.Abstract;
using ECommerce.Cargo.DataAccess.Context;
using ECommerce.Cargo.DataAccess.Repositories;
using ECommerce.Cargo.Entity.Concrete;

namespace ECommerce.Cargo.DataAccess.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {

        }
    }
}

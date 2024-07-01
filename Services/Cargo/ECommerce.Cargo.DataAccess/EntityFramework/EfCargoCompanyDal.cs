using ECommerce.Cargo.DataAccess.Abstract;
using ECommerce.Cargo.DataAccess.Context;
using ECommerce.Cargo.DataAccess.Repositories;
using ECommerce.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.DataAccess.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {

        }
    }
}

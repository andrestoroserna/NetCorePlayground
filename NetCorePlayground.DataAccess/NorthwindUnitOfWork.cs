using System;
using System.Collections.Generic;
using System.Text;
using NetCorePlayground.Repositories;
using UnitOfWork;

namespace NetCorePlayground.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }
    }
}

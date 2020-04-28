using NetCorePlayground.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
    }
}

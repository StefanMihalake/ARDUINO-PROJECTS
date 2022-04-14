using ApiTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.AppCore.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<TProduct, int>
    {

    }
}

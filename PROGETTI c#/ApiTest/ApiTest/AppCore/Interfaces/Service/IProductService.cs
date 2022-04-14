using ApiTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.AppCore.Interfaces.Service
{
    interface IProductService
    {
        Task<IEnumerable<TProduct>> GetAll();
        Task<TProduct> Get(int id);
        Task<TProduct> Insert(TProduct product);
        void Update();
        void Delete(int id);
    }
}

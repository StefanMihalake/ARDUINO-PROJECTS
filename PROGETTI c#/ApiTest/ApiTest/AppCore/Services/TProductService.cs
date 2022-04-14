using ApiTest.AppCore.Interfaces.Service;
using ApiTest.Domain.Models;
using ApiTest.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.AppCore.Services
{
    public class TProductService : IProductService
    {
        private readonly TProductRepository _productRepository;

        public TProductService(TProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public async Task<TProduct> Get(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<IEnumerable<TProduct>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<TProduct> Insert(TProduct product)
        {
            return await _productRepository.Insert(product);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

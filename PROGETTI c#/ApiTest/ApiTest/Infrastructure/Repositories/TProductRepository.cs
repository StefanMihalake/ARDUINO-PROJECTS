using ApiTest.AppCore.Interfaces.Repositories;
using ApiTest.Domain.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Infrastructure.Repositories
{
    public class TProductRepository : IProductRepository
    {
        private readonly IConfiguration _config;

        public TProductRepository(IConfiguration config)
        {
            _config = config;
        }

        public async void Delete(int id)
        {
            var cs = _config.GetConnectionString("testvs");
            using (var DB = new NpgsqlConnection(cs))
            {
                await DB.DeleteAsync<TProduct>(id);
            }
        }

        public async Task<TProduct> Get(int id)
        {
            var cs = _config.GetConnectionString("testvs");
            using (var DB = new NpgsqlConnection(cs))
            {
                return (TProduct)await DB.QueryAsync<TProduct>(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<TProduct>> GetAll()
        {
            var cs = _config.GetConnectionString("testvs");
            using (var DB = new NpgsqlConnection(cs))
            {
                return await DB.QueryAllAsync<TProduct>();
            }
        }

        public async Task<TProduct> Insert(TProduct product)
        {
            throw new NotImplementedException();
        }

        public async void Update()
        {
            throw new NotImplementedException();
        }
    }
}

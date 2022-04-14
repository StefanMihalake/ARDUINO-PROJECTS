using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.AppCore.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TPrimaryKey>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(TPrimaryKey id);
        Task<TEntity> Insert(TEntity entity);
        void Update();
        void Delete(TPrimaryKey id);
    }
}
using RDS.Fantedepo.Client.DataAccess.Helpers;

namespace RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions
{
    public interface ICrudRepository<T> where T : class
    {
        Task<int> Create(T obj);
        Task<bool> Delete(int id);
        Task<T?> Get(int id, IQueryParameters parameters = null!);
        Task<IEnumerable<T>> Get(IQueryParameters parameters = null!);
        Task<bool> Update(int id, T obj);
    }
}
using RDS.Fantadepo.Shared.SearchCriteria.Abstractions;

namespace RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions
{
    public interface ICrudRepository<T> where T : class
    {
        Task<int> Create(T obj);
        Task<bool> Delete(int id);
        Task<T?> Get(int id, ISearchCriteria parameters = null!);
        Task<IEnumerable<T>> Get(ISearchCriteria parameters = null!);
        Task<int> Update(int id, T obj);
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix.Interfaces
{
    public interface IRepository<T> where T : class , IEntity, new()
    {
        IQueryable<T> Items { get; }

        T GetById(int id);
        Task<T> GetByIdAsync(int id, CancellationToken cancel = default);

        T Add(T item);
        Task<T> AddAsync(T items, CancellationToken cancel = default);

        void Update(T item);
        Task UpdateAsync(T items, CancellationToken cancel = default);

        void Delete(int id);
        Task DeleteAsync(int id, CancellationToken cancel = default);
    }
}

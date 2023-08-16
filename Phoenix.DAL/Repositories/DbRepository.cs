using Microsoft.EntityFrameworkCore;
using Phoenix.DAL.Context;
using Phoenix.DAL.Entityes.Base;
using Phoenix.Interfaces;

namespace Phoenix.DAL.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T : EntityBase, new()
    {
        private readonly PhoenixDB _db;
        private readonly DbSet<T> _set;

        public DbRepository(PhoenixDB db)
        {
            _db = db;
            _set = _db.Set<T>();
        }
        public virtual IQueryable<T> Items => _set;

        public T Add(T item)
        {
            if(item is null)
                throw new ArgumentNullException(nameof(item));

            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();

            return item;        
        }

        public async Task<T> AddAsync(T items, CancellationToken cancel = default)
        {
            if(items is null)
                throw new ArgumentNullException(nameof(items));

            _db.Entry(items).State = EntityState.Added;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);

            return items;
        }

        public void Delete(int id)
        {
            var item = _set.Local.FirstOrDefault(i => i.Id == id) ?? new T {Id = id};

            _db.Remove(item);
            _db.SaveChanges();
        }

        public async Task DeleteAsync(int id, CancellationToken cancel = default)
        {
            _db.Remove(new {Id = id});
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public T GetById(int id) => Items.SingleOrDefault(Items => Items.Id == id);


        public async Task<T> GetByIdAsync(int id, CancellationToken cancel = default) => await Items
            .SingleOrDefaultAsync(Items => Items.Id == id, cancel)
            .ConfigureAwait(false);


        public void Update(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T items, CancellationToken cancel = default)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            _db.Entry(items).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}

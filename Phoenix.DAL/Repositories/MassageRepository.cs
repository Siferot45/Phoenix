using Microsoft.EntityFrameworkCore;
using Phoenix.DAL.Context;
using Phoenix.DAL.Entityes;

namespace Phoenix.DAL.Repositories
{
    internal class MassageRepository : DbRepository<Massage>
    {
        public override IQueryable<Massage> Items => base.Items.Include(item => item.Category);
        public MassageRepository(PhoenixDB db) : base(db) { }
    }
}

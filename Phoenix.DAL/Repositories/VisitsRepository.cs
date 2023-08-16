using Microsoft.EntityFrameworkCore;
using Phoenix.DAL.Context;
using Phoenix.DAL.Entityes;

namespace Phoenix.DAL.Repositories
{
    internal class VisitsRepository : DbRepository<Visit>
    {
        public override IQueryable<Visit> Items => base.Items
            .Include(item => item.Massage)
            .Include(item => item.Master)
            .Include(item => item.Client)
            ;
        public VisitsRepository(PhoenixDB db) : base(db) { }
    }
}

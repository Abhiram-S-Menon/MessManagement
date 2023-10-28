using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.IRepository;

namespace WebApplication2.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public DetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Detail obj)
        {
            _db.Details.Update(obj);
        }
    }

}

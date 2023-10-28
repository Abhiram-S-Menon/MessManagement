using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.IRepository;

namespace WebApplication2.Repository
{
    public class MessMemberRepository : Repository<MessMember>, IMessMemberRepository
    {
        private readonly ApplicationDbContext _db;
        public MessMemberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MessMember obj)
        {
            _db.MessMembers.Update(obj);
        }
    }

}

using WebApplication2.Data;
using WebApplication2.Repository.IRepository;

namespace WebApplication2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        
        public IDetailRepository Detail { get; private set; }
        public IMessMemberRepository MessMember { get;set;}
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;      
            Detail = new DetailRepository(_db);
            MessMember = new MessMemberRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

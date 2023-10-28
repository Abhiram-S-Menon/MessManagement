using WebApplication2.Models;

namespace WebApplication2.Repository.IRepository
{
    public interface IMessMemberRepository:IRepository<MessMember>
    {
        void Update(MessMember obj);
    }
}

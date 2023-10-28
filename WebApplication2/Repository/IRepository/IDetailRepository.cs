using WebApplication2.Models;

namespace WebApplication2.Repository.IRepository
{
    public interface IDetailRepository:IRepository<Detail>
    {
        void Update(Detail obj);
    }
}

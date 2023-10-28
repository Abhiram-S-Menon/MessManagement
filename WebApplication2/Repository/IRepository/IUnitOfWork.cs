namespace WebApplication2.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDetailRepository Detail { get; }
        IMessMemberRepository MessMember { get; }

        void Save();
    }
}

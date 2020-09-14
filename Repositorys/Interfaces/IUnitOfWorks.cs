namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IUnitOfWorks
    {
        IAuthRepository AuthRepository { get; }
        void Commit();
        void Rollback();
         
    }
}
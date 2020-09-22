namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IUnitOfWorks
    {
        ILog4NetRepository Log4NetRepository { get; }
        IAuthRepository AuthRepository { get; }
        void Commit();
        void Rollback();
         
    }
}
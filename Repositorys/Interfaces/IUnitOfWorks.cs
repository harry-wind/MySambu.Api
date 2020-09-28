using MySambu.Api.Repositorys.Interfaces.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IUnitOfWorks
    {
        ILog4NetRepository Log4NetRepository { get; }
        IAuthRepository AuthRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IOrganizationStructureRepository OrganizationStructure { get; }
        void Commit();
        void Rollback();
         
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.PPH;
using MySambu.Api.Models.Transaksi.PPH;

namespace MySambu.Api.Repositorys.Interfaces.Transaksi
{
    public interface IPPHRepository : IBaseRepository<PPH>
    {
        Task<IEnumerable<PPHDto>> GetAlls();
        Task<IEnumerable<PPH>> GetAllHeader();
        Task<IEnumerable<PPHDetail>> GetAllDetail();
        Task<IEnumerable<PPHListDto>> GetAllByParam(PPHParameterDto obj);
        Task<PPHDto> SaveAll(PPHDto obj);
        Task<PPHDto> UpdateAll(PPHDto obj);
        Task<PPHDto> GetByGuid(string hdrGuid);
        Task<IEnumerable<PPHFindItemDto>> FindItem(PPHFindItemParam obj);
    }
}
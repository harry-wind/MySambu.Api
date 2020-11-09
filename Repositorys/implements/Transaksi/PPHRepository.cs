using System.Linq;
using System.Diagnostics;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Transaksi.PPH;
using MySambu.Api.Repositorys.Interfaces.Transaksi;
using Dapper;
using MySambu.Api.DTO.Transaksi.PPH;
using Dapper.Contrib.Extensions;
using System;

namespace MySambu.Api.Repositorys.implements.Transaksi
{
    internal class PPHRepository : BaseRepository, IPPHRepository
    {
        public PPHRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
        public Task Delete(PPH obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PPH>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<PPHListDto>> GetAllByParam(PPHParameterDto obj)
        {
            var result = await Connection.QueryAsync<PPHListDto>("pTrn_PphList", new {
                TransDate1 = obj.TransDate1,
                TransDate2 = obj.TransDate2,
                PPHNo = obj.PPHNo,
                SupplierID = obj.SupplierID,
                ItemName = obj.ItemName
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return result;
        }

        public async Task<IEnumerable<PPHDetail>> GetAllDetail()
        {
            string sql = "Select * From tTrn_PPHDtl ";
            return await Connection.QueryAsync<PPHDetail>(sql, transaction: Transaction);
        }

        public async Task<IEnumerable<PPH>> GetAllHeader()
        {
            string sql = "Select * From tTrn_PPHHdr ";
            return await Connection.QueryAsync<PPH>(sql, transaction: Transaction);
        }

        public async Task<IEnumerable<PPHDto>> GetAlls()
        {
            string sql = @"Select TOP 1000 a.PPHHdrGuid, a.PPHID, a.PPHNo, a.SupplierPPHRef, a.TransDate, a.SupplierID, a.PriceInd, a.Remark
                    , b.PPHHdrGuid, b.PPHDtlID, b.PPHID, b.ItemID, b.ItemName, b.Qnty, b. CurrencyID, b.UnitPrice, b.ExchangerateIDR, b.WeekNo
                    , b.DeliveryDate, b.DetailRemark, b.ShowSpecInd, b.PPBID, b.ItemIDOld, b.ValidUntil, b.RevisionNo, b.CreatedBy, b.CreatedDate
                    , b.UpdatedBy, b.UpdatedDate, b.Computer, b.ComputerDate
                    From tTrn_PPHHdr as a 
	                LEFT OUTER JOIN	tTrn_PPHDtl as b ON b.PPHHdrGuid = a.PPHHdrGuid";
            var pphDic = new Dictionary<long, PPHDto>();

            await Connection.QueryAsync<PPHDto, PPHDetail, PPHDto>(
                sql, 
                (pph, PPHDetail) => 
                {
                    PPHDto PPHs;
                    if (!pphDic.TryGetValue(pph.PPHID, out PPHs))
                    {                        
                        PPHs = pph;
                        PPHs.PPHDetails = new List<PPHDetail>();
                        pphDic.Add(PPHs.PPHID, PPHs);
                    }

                    PPHs.PPHDetails.Add(PPHDetail);
                    return PPHs;
                }, splitOn: "PPHHdrGuid", transaction: Transaction);
            
            return pphDic.Values;            
        }

        public async Task<PPHDto> GetByGuid(string hdrGuid)
        {
            string sql = @"Select TOP 1000 a.PPHHdrGuid, a.PPHID, a.PPHNo, a.SupplierPPHRef, a.TransDate, a.SupplierID, a.PriceInd, a.Remark
                    , b.PPHHdrGuid, b.PPHDtlID, b.PPHID, b.ItemID, b.ItemName, b.Qnty, b. CurrencyID, b.UnitPrice, b.ExchangerateIDR, b.WeekNo
                    , b.DeliveryDate, b.DetailRemark, b.ShowSpecInd, b.PPBID, b.ItemIDOld, b.ValidUntil, b.RevisionNo, b.CreatedBy, b.CreatedDate
                    , b.UpdatedBy, b.UpdatedDate, b.Computer, b.ComputerDate
                    From tTrn_PPHHdr as a 
	                LEFT OUTER JOIN	tTrn_PPHDtl as b ON b.PPHHdrGuid = a.PPHHdrGuid
                    WHERE a.PPHHdrGuid = @hdrGuid ";
            var pphDic = new Dictionary<long, PPHDto>();

            await Connection.QueryAsync<PPHDto, PPHDetail, PPHDto>(
                sql, 
                (pph, PPHDetail) => 
                {
                    PPHDto PPHs;
                    if (!pphDic.TryGetValue(pph.PPHID, out PPHs))
                    {                        
                        PPHs = pph;
                        PPHs.PPHDetails = new List<PPHDetail>();
                        pphDic.Add(PPHs.PPHID, PPHs);
                    }

                    PPHs.PPHDetails.Add(PPHDetail);
                    return PPHs;
                }, splitOn: "PPHHdrGuid", param: new{hdrGuid=hdrGuid}, transaction: Transaction);
            
            return pphDic.Values.First();    
        }

        public Task<PPH> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PPH> Save(PPH obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PPHDto> SaveAll(PPHDto obj)
        {
            var paramHdr = new {
                PPHID = obj.PPHID,
                PPHHdrGuid = obj.PPHHdrGuid,
                PPHNo = obj.PPHNo,
                RevisionNo = obj.RevisionNo,
                SupplierPPHRef = obj.SupplierPPHRef,
                TransDate = obj.TransDate,
                SupplierID = obj.SupplierID,
                PriceInd = obj.PriceInd,
                Remark = obj.Remark,
                FileAttachment = obj.FileAttachment,
                UserBy = obj.CreatedBy,
                SupplierIDOld = obj.SupplierIDOld,
                PeriodePPHOnline = obj.PeriodePPHonline,
            };

            var hdr = await Connection.QueryFirstOrDefaultAsync<PPHDto>("pTrn_PPHHdr", paramHdr, commandType: CommandType.StoredProcedure, transaction: Transaction);

            PPHDto pphDtos = hdr;
            pphDtos.PPHDetails = new List<PPHDetail>();

            foreach (var dtl in obj.PPHDetails)
            {
                var paramDtl = new {
                    PPHDtlID = dtl.PPHDtlID,
                    PPHID = pphDtos.PPHID,
                    PPHHdrGuid = pphDtos.PPHHdrGuid,
                    ItemID = dtl.ItemID,
                    ItemName = dtl.ItemName,
                    RevisionNo = dtl.RevisionNo,
                    Qnty = dtl.Qnty,
                    CurrencyID = dtl.CurrencyID,
                    UnitPrice = dtl.UnitPrice,
                    ExchangeRateIDR = dtl.ExchangeRateIDR,
                    WeekNo = dtl.WeekNo,
                    DeliveryDate = dtl.DeliveryDate,
                    DetailRemark = dtl.DetailRemark,
                    ShowSpecInd = dtl.ShowSpecInd,
                    PPBID = dtl.PPBID,
                    UserBy = pphDtos.CreatedBy,
                    ItemIDOld = dtl.ItemIDOld,
                    ValidUntil = dtl.ValidUntil
                };

                var dtls = await Connection.QueryFirstOrDefaultAsync<PPHDetail>("pTrn_PPHDtl", paramDtl, commandType: CommandType.StoredProcedure, transaction: Transaction);

                pphDtos.PPHDetails.Add(dtl); 
            }

            return pphDtos;
        }

        public Task Update(PPH obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<PPHDto> UpdateAll(PPHDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
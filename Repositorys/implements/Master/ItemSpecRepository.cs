using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemSpecRepository : BaseRepository, IItemSpecRepository
    {
        // private IDbTransaction _transaction;

        public ItemSpecRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(ItemSpec obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("Updated tMst_ItemSpec SET IsActive = false, UpdatedBy = @by, UpdatedDate = @tgl WHERE ItemSpecID = @id ", new { by = by, tgl = DateTime.Now, id = id}, transaction: Transaction);
        }

        public async Task<IEnumerable<ItemSpec>> GetAll()
        {
            return await Connection.GetAllAsync<ItemSpec>(transaction:Transaction);
        }

        public async Task<ItemSpec> GetByID(string id)
        {
            var sql = "SELECT A.*, B.ItemSpecDtlID, B.VariantValueID, C.VariantValueName, C.VariantTypeID, D.VariantTypeName FROM tMst_ItemSpec A " +
                        " LEFT JOIN tMst_ItemSpecDtl B ON A.ItemSpecID = B.ItemSpecID " +
                        " LEFT JOIN tMst_ItemVariantValue C ON B.VariantValueID = C.VariantValueID " +
                        " LEFT JOIN tMst_ItemVariantType D ON C.VariantTypeID = D.VariantTypeID WHERE A.ItemSpecID = @id";

            var bhdr = new Dictionary<string, ItemSpec>();
            await Connection.QueryAsync<ItemSpec, ItemSpecDtl, ItemSpec>(sql, (hdr, dtl) => {
                ItemSpec biHdr;

                if(!bhdr.TryGetValue(hdr.ItemSpecID, out biHdr)){
                    biHdr = hdr;
                    biHdr.ItemSpecDtl = new List<ItemSpecDtl>();
                    bhdr.Add(biHdr.ItemSpecID, biHdr);
                }

                biHdr.ItemSpecDtl.Add(dtl);

                return biHdr;
                
            }, splitOn: "ItemSpecDtlID", param: new{id=id}, transaction:Transaction);

            return bhdr.Values.First();
            // return await Connection.QueryFirstOrDefaultAsync<ItemSpec>("SELECT * FROM tMst_ItemSpec WHERE ItemSpecID = @id", new { id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemSpec>> GetByItem(string id)
        {
            var sql = "SELECT A.*, B.ItemSpecDtlID, B.VariantValueID, C.VariantValueName, C.VariantTypeID, D.VariantTypeName FROM tMst_ItemSpec A " +
                        " LEFT JOIN tMst_ItemSpecDtl B ON A.ItemSpecID = B.ItemSpecID " +
                        " LEFT JOIN tMst_ItemVariantValue C ON B.VariantValueID = C.VariantValueID " +
                        " LEFT JOIN tMst_ItemVariantType D ON C.VariantTypeID = D.VariantTypeID WHERE A.ItemId = @id";

            var bhdr = new Dictionary<string, ItemSpec>();

            await Connection.QueryAsync<ItemSpec, ItemSpecDtl, ItemSpec>(sql, (hdr, dtl) => {
                ItemSpec biHdr;

                if(!bhdr.TryGetValue(hdr.ItemSpecID, out biHdr)){
                    biHdr = hdr;
                    biHdr.ItemSpecDtl = new List<ItemSpecDtl>();
                    bhdr.Add(biHdr.ItemSpecID, biHdr);
                }

                biHdr.ItemSpecDtl.Add(dtl);

                return biHdr;
                
            }, splitOn: "ItemSpecDtlID", param: new{id=id}, transaction:Transaction);

            return bhdr.Values;
            // return await Connection.QueryAsync<ItemSpec>("SELECT * FROM tMst_ItemSpec WHERE ItemID = @id", new { id = itemid}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemTypeVariantDto>> GetByName(string name)
        {
            var sql = "SELECT A.VariantTypeID, A.VariantTypeName, B.VariantValueID, B.VariantValueName FROM tMst_ItemVariantType A INNER JOIN tMst_ItemVariantValue B ON A.VariantTypeID = B.VariantTypeID " +
                        " WHERE A.IsActive = 1 AND A.VariantTypeName like CONCAT('%', @name, '%') OR B.VariantValueName like CONCAT('%', @name, '%')";

            return await Connection.QueryAsync<ItemTypeVariantDto>(sql, new { name = name}, transaction:Transaction);
        }

        public async Task<ItemSpec> Save(ItemSpec obj)
        {
            // await Connection.InsertAsync<ItemSpec>(obj, transaction:Transaction); 
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemSpec>("pMst_ItemSpecSave", new
            {
                ItemSpecID = obj.ItemSpecID,
                ItemID = obj.ItemID,
                DetailSpesifikasi = obj.Deskripsi,
                UOM = obj.UOM,
                Qnty = obj.QntyConvert,
                IsActive = obj.IsActive,
                ComputerName = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0 
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            var hdr = dt.ItemSpecID;

            if(obj.ItemSpecDtl != null){
                foreach(var r in obj.ItemSpecDtl){
                    await Connection.QueryFirstOrDefaultAsync<ItemSpec>("pMst_ItemSpecDtlSave", new
                    {
                        ItemSpecDtlID = r.ItemSpecDtlID,
                        ItemSpecID = hdr,
                        VariantValueID = r.VariantValueID,
                        ComputerName = obj.Computer,
                        UserID = obj.CreatedBy,
                        Flag = 0 
                    }, commandType: CommandType.StoredProcedure, transaction: Transaction); 
                }
            }

            var dtl = await Connection.QueryAsync<ItemSpecDtl>("SELECT * FROM vMst_ItemSpecDtl where ItemSpecID = @id", new{id = hdr}, transaction:Transaction);
            dt.ItemSpecDtl = dtl.ToList();
            return dt;
        }

        public async Task Update(ItemSpec obj)
        {
            await Connection.QueryAsync("Updated tMst_ItemSpec SET DetailSpesifikasi = @spec, UpdatedBy = @by, UpdatedDate = @tgl  WHERE ID = @id ", new { spec = obj.Deskripsi, by = obj.CreatedBy, tgl = DateTime.Now, id = obj.ItemSpecID}, transaction: Transaction);
        }
    }
}
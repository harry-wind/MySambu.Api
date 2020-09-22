using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using log4net;
using log4net.Appender;
using log4net.Core;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Models;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class Log4NetRepository : BaseRepository, ILog4NetRepository
    {
        // private IDbTransaction _transaction;

        public Log4NetRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task<int> Delete(Log obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Log>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Save(Log obj)
        {
            var result = 0;

            try
            {
                await Connection.InsertAsync<Log>(obj, transaction:Transaction);
                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public Task<int> Update(Log obj)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Log4NetAppender : AppenderSkeleton
    {
        private IConfiguration _config;
        private IUnitOfWorks _uow;

        public Log4NetAppender(IConfiguration config, IUnitOfWorks uow)
        {
            _config = config;
            _uow = uow;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var newValue = (loggingEvent.LookupProperty("NewValue") != null) ? loggingEvent.LookupProperty("NewValue").ToString() : string.Empty;
            var oldValue = (loggingEvent.LookupProperty("OldValue") != null) ? loggingEvent.LookupProperty("OldValue").ToString() : string.Empty;
            var createdBy = (loggingEvent.LookupProperty("UserName") != null) ? loggingEvent.LookupProperty("UserName").ToString() : string.Empty;

            var log = new Log
            {
                Level = loggingEvent.Level.ToString(),
                ClassName = loggingEvent.LocationInformation.ClassName,
                MethodName = loggingEvent.LocationInformation.MethodName,
                Message = loggingEvent.RenderedMessage,
                NewValue = newValue,
                OldValue = oldValue,
                Exception = loggingEvent.GetExceptionString(),
                CreatedBy = createdBy
            };

            LogicalThreadContext.Properties.Clear();

            // var result = 0;
            try
            {
                 _uow.Log4NetRepository.Save(log);
                 _uow.Commit();
            }
            catch (System.Exception)
            {
               _uow.Rollback();
            }
           
            
        }
    }
}
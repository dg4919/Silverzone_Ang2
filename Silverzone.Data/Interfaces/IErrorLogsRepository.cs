using Silverzone.Entities;
using System;

namespace Silverzone.Data
{
    public interface IErrorLogsRepository : IRepository<ErrorLogs>
    {
        ErrorLogs logError(Exception exception);
    }
}

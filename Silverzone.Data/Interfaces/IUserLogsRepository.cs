using Silverzone.Entities;
using System;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public interface IUserLogsRepository:IRepository<UserLogs>
    {
        UserLogs GetById(int id);
        IEnumerable<UserLogs> GetByDate(DateTime sdate);
        IEnumerable<UserLogs> GetByUserId(int id);
    }
}

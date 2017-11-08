using Silverzone.Entities;
using System;
using System.Collections.Generic;

namespace Silverzone.Data.Interfaces
{
    public interface IQueryRepository:IRepository<Query>
    {
        Query GetById(int id);
        IEnumerable<Query> GetByStatus(string status);
        IEnumerable<Query> GetByQueryDate(DateTime qdate);
        IEnumerable<Query> GetByCloseDate(DateTime cdate);
    }
}

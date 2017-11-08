using Silverzone.Data.Interfaces;
using Silverzone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data.Repositories
{
    public class QueryRepository:BaseRepository<Query>,IQueryRepository
    {
        public QueryRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Query GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Query> GetByStatus(string status)
        {
            return _dbset.Where(x => x.QueryStatus == status).AsEnumerable();
        }

        public IEnumerable<Query> GetByQueryDate(DateTime qdate)
        {
            return _dbset.Where(x => x.QueryDate == qdate).AsEnumerable();
        }

        public IEnumerable <Query> GetByCloseDate(DateTime cdate)
        {
            return _dbset.Where(x => x.CloseDate ==cdate).AsEnumerable();
        }
    }
}

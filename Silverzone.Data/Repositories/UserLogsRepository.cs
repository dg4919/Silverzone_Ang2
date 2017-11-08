using Silverzone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class UserLogsRepository:BaseRepository<UserLogs>,IUserLogsRepository
    {
        public UserLogsRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public UserLogs GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
         public IEnumerable<UserLogs>  GetByDate(DateTime sdate)
        {
            return _dbset.Where(x => x.Login_DateTime == sdate).AsEnumerable();
        }

        public IEnumerable<UserLogs> GetByUserId(int id)
        {
            return _dbset.Where(x => x.UserId == id).AsEnumerable();
        }
    }
}

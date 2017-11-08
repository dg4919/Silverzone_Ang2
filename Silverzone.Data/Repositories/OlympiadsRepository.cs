using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public  class OlympiadsRepository:BaseRepository<Olympiads>,IOlympiadsRepository
    {
        public OlympiadsRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Olympiads GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Olympiads> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.Status == status).AsEnumerable();
        }
    }
}

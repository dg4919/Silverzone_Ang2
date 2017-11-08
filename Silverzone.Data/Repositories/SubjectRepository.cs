using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class SubjectRepository:BaseRepository<Subject>,ISubjectRepository
    {
        public SubjectRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Subject GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public Subject GetByName(string name)
        {
            return FindBy(x => x.Name == name).FirstOrDefault();
        }
        public IEnumerable<Subject> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.Status == status).AsEnumerable();
        }
    }
}

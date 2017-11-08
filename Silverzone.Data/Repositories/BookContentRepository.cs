using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class BookContentRepository : BaseRepository<BookContent>, IBookContentRepository
    {
        public BookContentRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public BookContent GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public BookContent GetByName(string name)
        {
            return FindBy(x => x.Name == name).FirstOrDefault();
        }

        public IEnumerable<BookContent> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.Status == status).AsEnumerable();
        }

        public void deleteWhere(IEnumerable<BookContent> contents)
        {
            // RemoveRange is attach with specific table and context clas
            _dbContext.Contents.RemoveRange(contents);
        }
    }
}

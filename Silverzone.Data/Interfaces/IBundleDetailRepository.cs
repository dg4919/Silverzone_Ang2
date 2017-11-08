using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IBundleDetailRepository : IRepository<BookBundleDetails>
    {
        BookBundleDetails GetById(int id);
        //BookBundle GetByBookId(int id);
    }
}

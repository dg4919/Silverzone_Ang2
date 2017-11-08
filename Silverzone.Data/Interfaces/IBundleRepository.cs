using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IBundleRepository:IRepository<BookBundle>
    {
        BookBundle GetById(int id);
        //BookBundle GetByBookId(int id);
    }
}

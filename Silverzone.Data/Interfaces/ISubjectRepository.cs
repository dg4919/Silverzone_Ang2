using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface ISubjectRepository:IRepository<Subject>
    {
        Subject GetById(int id);
        Subject GetByName(string name);
        IEnumerable<Subject> GetByStatus(bool status);
    }
}

using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public interface IQuickLinkRepository:IRepository<QuickLink>
    {
        QuickLink GetById(int id);
        IEnumerable<QuickLink> GetByStatus(bool status);
    }
}

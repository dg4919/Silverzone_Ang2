using System;
using Silverzone.Entities;

namespace Silverzone.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private SilverzoneContext _dbContext;
        public UnitOfWork(SilverzoneContext context)
        {
            _dbContext = context;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        // automatically call, when a fx > Edit/update/delete is finish
        // use to clear connection from DB > e.g dbContext
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}

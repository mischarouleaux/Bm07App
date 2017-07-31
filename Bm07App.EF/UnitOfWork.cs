using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Interfaces;

namespace Bm07App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CasusBM07Context _context;

        private bool _disposed;

        public UnitOfWork(CasusBM07Context context)
        {
            _context = context;
        }

        public virtual void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Log error.
                throw;
            }
        }

        public virtual async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //TODO: Log error.
                throw;
            }
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}


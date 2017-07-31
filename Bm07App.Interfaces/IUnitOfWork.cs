using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm07App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit the changes to the data store.
        /// </summary>
        void Commit();

        /// <summary>
        /// Commit the changes to the data store asynchronously.
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}

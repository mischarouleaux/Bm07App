using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm07App.Models.Interfaces
{
    public interface ISoftDelete
    {
        bool IsActive { get; set; }
    }
}
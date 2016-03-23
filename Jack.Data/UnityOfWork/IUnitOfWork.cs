using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}

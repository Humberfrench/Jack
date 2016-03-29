using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public interface ICrud<TClass, keyType>
    {

        bool Insert(TClass oTipo);
        bool Update(TClass oTipo);
        bool Delete(TClass oTipo);
        TClass Find(keyType Identifier);
        IList<TClass> LoadAll();

    }
}

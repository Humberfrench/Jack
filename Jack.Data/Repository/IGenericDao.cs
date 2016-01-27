using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Data
{
    public interface IGenericDao<Tipo, ID>
    {

        bool Insert(Tipo oTipo);
        bool Update(Tipo oTipo);
        bool Delete(Tipo oTipo);
        Tipo Find(ID Identifier);
        IList<Tipo> LoadAll();

    }
}

using System.Collections.Generic;
using Jack.Model;

namespace Jack.Repository
{
    public interface ITipoItemRep
    {
        bool Delete(TipoItem oTipo);
        TipoItem Find(int Identifier);
        bool Insert(TipoItem oTipo);
        IList<TipoItem> LoadAll();
        bool Update(TipoItem oTipo);
    }
}
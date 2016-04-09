using System.Collections.Generic;


namespace Jack.Model
{
    public interface ITipoItemApp
    {
        bool Delete(TipoItem oTipo);
        TipoItem Find(int Identifier);
        bool Insert(TipoItem oTipo);
        IList<TipoItem> LoadAll();
        bool Update(TipoItem oTipo);
    }
}
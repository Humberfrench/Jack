using System.Collections.Generic;

namespace Jack.Model
{
    public interface IRoupaRep
    {
        bool Delete(Roupa oTipo);
        Roupa Find(int Identifier);
        bool Insert(Roupa oTipo);
        IList<Roupa> LoadAll();
        bool Update(Roupa oTipo);
    }
}
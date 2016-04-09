using System.Collections.Generic;


namespace Jack.Model
{
    public interface IResponsavelApp
    {
        bool Delete(Responsavel oTipo);
        Responsavel Find(int Identifier);
        bool Insert(Responsavel oTipo);
        IList<Responsavel> LoadAll();
        bool Update(Responsavel oTipo);
    }
}
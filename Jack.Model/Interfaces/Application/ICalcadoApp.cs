using System.Collections.Generic;

namespace Jack.Model
{
    public interface ICalcadoApp
    {
        bool Delete(Calcado oTipo);
        Calcado Find(int Identifier);
        bool Insert(Calcado oTipo);
        IList<Calcado> LoadAll();
        bool Update(Calcado oTipo);
    }
}
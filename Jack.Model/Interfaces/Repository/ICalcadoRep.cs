using System.Collections.Generic;

namespace Jack.Model
{
    public interface ICalcadoRep
    {
        bool Insert(Calcado oTipo);
        bool Update(Calcado oTipo);
        bool Delete(Calcado oTipo);
        IList<Calcado> LoadAll();
        Calcado Find(int ID);
    }
}

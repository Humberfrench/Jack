using Jack.DTO;
using System.Collections.Generic;

namespace Jack.Model
{
    public interface IFamiliaRep
    {
        bool Insert(Model.Familia oTipo);
        bool Update(Model.Familia oTipo);
        bool Delete(Model.Familia oTipo);
        IList<Familia> LoadAll();
        Familia Find(int ID);
        string GravarLote(Familia oFamilia);
        IList<DTOFamiliaChamada> ObterChamada(int intReuniao);
        IList<DTOFamilia> Load();

    }
}

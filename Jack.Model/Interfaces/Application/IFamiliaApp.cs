using System.Collections.Generic;
using Jack.DTO;


namespace Jack.Model
{
    public interface IFamiliaApp
    {
        bool Delete(int ID);
        Familia Find(int Identifier);
        bool Gravar(DTOFamilia family);
        List<FamiliaLote> GravarLote(List<string> lstNomeMaes);
        bool Insert(Familia oTipo);
        IList<DTOFamilia> Load();
        IList<Familia> LoadAll();
        string LoadJSON();
        DTOFamilia Obter(int ID);
        IList<DTOFamiliaChamada> ObterChamada(int intReuniao);
        bool Update(Familia oTipo);
    }
}
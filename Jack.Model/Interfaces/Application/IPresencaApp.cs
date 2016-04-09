using System.Collections.Generic;
using Jack.DTO;


namespace Jack.Model
{
    public interface IPresencaApp
    {
        bool Delete(Presenca oTipo);
        Presenca Find(int Identifier);
        bool Insert(Presenca oTipo);
        bool InsertLote(IList<Presenca> lstFamilia);
        IList<Familia> Load(int intReuniao);
        IList<Presenca> LoadAll();
        IList<FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno);
        bool Registrar(DTOPresenca presencaMae);
        bool Update(Presenca oTipo);
    }
}
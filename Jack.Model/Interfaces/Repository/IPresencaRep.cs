using System.Collections.Generic;
using Jack.DTO;

namespace Jack.Model
{
    public interface IPresencaRep
    {
        bool Delete(Presenca oTipo);
        Presenca Find(int Identifier);
        bool Insert(Presenca oTipo);
        IList<Familia> Load(int intReuniao);
        IList<Presenca> LoadAll();
        IList<FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno);
        bool Update(Presenca oTipo);
    }
}
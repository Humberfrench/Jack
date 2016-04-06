using System.Collections.Generic;
using Jack.DTO;
using Jack.Model;

namespace Jack.Model
{
    public interface IReuniaoRep
    {
        bool Delete(Reuniao oTipo);
        Reuniao Find(int Identifier);
        bool Insert(Reuniao oTipo);
        IList<Reuniao> LoadAll();
        IList<DTOReuniao> LoadByAnoCorrente(int intAno);
        bool Update(Reuniao oTipo);
    }
}
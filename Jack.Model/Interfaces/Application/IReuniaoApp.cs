using System;
using System.Collections.Generic;
using Jack.DTO;


namespace Jack.Model
{
    public interface IReuniaoApp
    {
        bool AddDatas(int intAno);
        bool Delete(Reuniao oTipo);
        Reuniao Find(int Identifier);
        List<Reuniao> GerarDatas(int intAno);
        bool Insert(Reuniao oTipo);
        IList<Reuniao> Load(int intAno);
        IList<Reuniao> LoadAll();
        IList<DTOReuniao> LoadByAnoCorrente(int intAno);
        int ObterDatasReuniaoAno(DateTime strData, int intAno);
        bool Update(Reuniao oTipo);
    }
}
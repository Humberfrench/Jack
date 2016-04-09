using System.Collections.Generic;
using Jack.DTO;


namespace Jack.Model
{
    public interface IStatusApp
    {
        bool Delete(Status oTipo);
        Status Find(int Identifier);
        bool Insert(Status oTipo);
        IList<DTOStatus> Load();
        IList<Status> LoadAll();
        IList<DTOStatus> LoadForCriancas();
        IList<DTOStatus> LoadForFamilia();
        bool Update(Status oTipo);
    }
}
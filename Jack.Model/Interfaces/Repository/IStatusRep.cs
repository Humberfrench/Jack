using System.Collections.Generic;
using Jack.DTO;

namespace Jack.Model
{
    public interface IStatusRep
    {
        bool Delete(Status oTipo);
        Status Find(int Identifier);
        bool Insert(Status oTipo);
        IList<DTOStatus> Load();
        IList<Status> LoadAll();
        bool Update(Status oTipo);
    }
}
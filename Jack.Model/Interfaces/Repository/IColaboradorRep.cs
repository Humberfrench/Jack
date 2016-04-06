using System.Collections.Generic;

namespace Jack.Model
{
    public interface IColaboradorRep
    {
        bool Delete(Colaborador oTipo);
        Colaborador Find(int Identifier);
        bool Insert(Colaborador oTipo);
        IList<Colaborador> ListaQuantidadeSacolasPorColaborador(int intAno);
        IList<Colaborador> LoadAll();
        bool Update(Colaborador oTipo);
    }
}
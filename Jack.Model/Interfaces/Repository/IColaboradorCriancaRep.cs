using System.Collections.Generic;

namespace Jack.Model
{
    public interface IColaboradorCriancaRep
    {
        bool Insert(ColaboradorCrianca oTipo);
        bool Update(ColaboradorCrianca oTipo);
        bool Delete(ColaboradorCrianca oTipo);
        IList<ColaboradorCrianca> LoadAll();
        ColaboradorCrianca Find(int ID);
        IList<Model.ColaboradorCrianca> ObterCriancasPorColaborador(int intColaborador, int intAno);

    }
}

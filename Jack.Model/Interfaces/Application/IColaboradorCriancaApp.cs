using System.Collections.Generic;


namespace Jack.Model
{
    public interface IColaboradorCriancaApp
    {
        bool Delete(ColaboradorCrianca oTipo);
        ColaboradorCrianca Find(int Identifier);
        bool Insert(ColaboradorCrianca oTipo);
        IList<ColaboradorCrianca> LoadAll();
        IList<ColaboradorCrianca> ObterCriancasPorColaborador(int intColaborador, int intAno);
        bool Update(ColaboradorCrianca oTipo);
    }
}
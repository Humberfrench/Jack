using System.Collections.Generic;
using Jack.DTO;

namespace Jack.Model
{
    public interface IFamiliaCriancaRep
    {
        bool DeleteCrianca(int intFamilia, int intCrianca);
        bool DeleteFamilia(int intFamilia);
        bool Insert(int intFamilia, int intCrianca);
        List<DTOCrianca> ObterCriancasByFamilia(int intFamilia);
        List<DTOCriancaRepresentante> ObterCriancasByFamiliaWithRep(int intFamilia);
    }
}
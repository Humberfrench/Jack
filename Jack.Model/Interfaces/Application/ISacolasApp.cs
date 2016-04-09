using System.Collections.Generic;
using Jack.DTO;

namespace Jack.Model
{
    public interface ISacolasApp
    {
        bool AddSacolaColaboradorCrianca(int intCrianca, int intColaborador, int intAno, bool isDevolvida);
        bool AddSacolaColaboradorSacola(int intSacola, int intColaborador, int intAno, bool isDevolvida);
        bool AddSacolaCrianca(int intCrianca);
        void GravarLogSacolas(string strListSacolasIn);
        IList<KitSacola> ObterKitSacolas(int intKit);
        IList<Sacolas> ObterSacolas();
        IList<Sacolas> ObterSacolas(string strListSacolasIn);
        IList<Sacolas> ObterSacolas(int intSacolaFamilia);
        IList<Sacolas> ObterSacolas(int intKit, int intNivel);
        IList<Sacolas> ObterSacolas(int intKit, int intNivel, string isPrinted);
        IList<Sacolas> ObterSacolasLivres(int intKit, int intNivel, string isPrinted);
        IList<Sacolas> ProcessaSacolas(int intAno);
    }
}
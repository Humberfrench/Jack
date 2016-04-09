using System.Collections.Generic;
using Jack.DTO;


namespace Jack.Model
{
    public interface IProcessosApp
    {
        bool AtualizaDadosCrianca();
        bool AtualizaDadosCrianca(int intCrianca);
        bool AtualizaDadosMae();
        IList<CriancasInconsistentes> ObterCriancasInconsistentes();
        IList<Familia> ObterFamiliasComZeroCriancas();
        IList<Familia> ObterFamiliasInconsistentes();
        bool ProcesaGeral(int intAno);
        bool ProcesaPresenca(int intAno);
        bool ProcessaPresencasRepresentantesReuniao(string strPresenca);
        bool ProcessaPresencasRepresentantesReuniao(int intReuniao);
    }
}
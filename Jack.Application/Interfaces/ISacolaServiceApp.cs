using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface ISacolaServiceApp : IServiceBase<SacolaViewModel>
    {

        ValidationResult AddCrianca(int crianca);
        byte[] GerarQrCode(int width, int height, CriancaViewModel crianca);
        byte[] GerarQrCode(int width, int height, SacolaViewModel sacola);
        byte[] GerarQrCode(int width, int height, int crianca);
        byte[] GerarQrCodeSacola(int width, int height, int sacola);
        ValidationResult Liberar(int id);
        IEnumerable<FamiliaViewModel> ObterFamiliasSacola();
        IEnumerable<SacolaValueViewModel> ObterSacolaParaImpressao(string sacolasNumero, int ano);
        IEnumerable<SacolaViewModel> ObterSacolasLivres(int ano, bool? liberado);
        IEnumerable<SacolaViewModel> ObterSacolasLivres(int nivel = 0, int liberado = 2);
        IEnumerable<SacolaViewModel> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, int familia = 0, string sexo = "", int kit = 0);
        IEnumerable<SacolaViewModel> ObterTodosPorNivel(int nivel, int liberado);
        List<SacolaViewModel> ProcessarSacolas(int ano);
        List<SacolaViewModel> ProcessarSacolas(int ano, bool todas);
        List<FamiliaViewModel> ProcessarSacolasEObterFamilias(int ano);
        List<FamiliaViewModel> ProcessarSacolasEObterFamilias(int ano, bool todas);
        void ValidarCrianca(CriancaViewModel crianca);
        IList<SacolaViewModel> PesquisarSacolas(int ano, int familia, int kit, int nivel);
        IList<SacolaViewModel> PesquisarSacolas(int familia);
        IList<SacolaViewModel> PesquisarSacolas(int kit, int nivel);
        IList<FamiliaViewModel> ObterFamilias(int nivel);
        ValidationResult AddCrianca(CriancaViewModel crianca);
        ValidationResult AddFamilia(int familia);
        IList<FamiliaViewModel> ObterFamiliasDisponiveis();

    }
}
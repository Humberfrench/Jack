using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface ISacolaServiceApp : IServiceBase<SacolaViewModel>
    {
        IEnumerable<SacolaViewModel> ObterTodosPorNivel(int nivel, int liberado);
        IEnumerable<FamiliaViewModel> ObterFamiliasSacola();
        ValidationResult AddCrianca(int crianca);
        ValidationResult Liberar(int id);
        IEnumerable<SacolaViewModel> ObterSacolasLivres(int nivel = 0, int liberado = 2);
        IEnumerable<SacolaViewModel> ObterSacolasLivres(int ano, bool? liberado);
        IEnumerable<SacolaViewModel> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, int familia = 0,
                                                        string sexo = "", int kit = 0);

        byte[] GerarQrCode(int width, int height, int crianca);
        byte[] GerarQrCode(int width, int height, CriancaViewModel crianca);
        byte[] GerarQrCode(int width, int height, SacolaViewModel sacola);
        byte[] GerarQrCodeSacola(int width, int height, int sacola);
    }
}
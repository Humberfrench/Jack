using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ISacolaService : IServiceBase<Sacola>
    {
        byte[] GerarQrCode(int width, int height, Crianca crianca);
        byte[] GerarQrCode(int width, int height, Sacola sacola);
        byte[] GerarQrCode(int width, int height, int crianca);
        byte[] GerarQrCodeSacola(int width, int height, int sacola);

        void AtualizarQrCodeSacolas();
        ValidationResult AtualizarQrCodeSacolas(int id);

        ValidationResult Liberar(int id);
        IEnumerable<Familia> ObterFamiliasSacola();
        IEnumerable<Sacola> ObterSacolasLivres(int ano, bool? liberado);
        IEnumerable<Sacola> ObterSacolasLivres(int nivel = 0, int liberado = 2);
        IEnumerable<Sacola> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, int familia = 0, string sexo = "", int kit = 0);
        IEnumerable<Sacola> ObterTodosPorNivel(int nivel, int liberado);
        List<Sacola> ProcessarSacolas(int ano);
        List<Sacola> ProcessarSacolas(int ano, bool todas);
        List<Familia> ProcessarSacolasEObterFamilias(int ano);
        List<Familia> ProcessarSacolasEObterFamilias(int ano, bool todas);
        void ValidarCrianca(Crianca crianca);
        IList<Sacola> ObterSacolaParaImpressao(string sacolasNumero, int ano);
        IList<Sacola> PesquisarSacolas(int ano, int familia, int kit, int nivel);
        IList<Sacola> PesquisarSacolas(int familia);
        IList<Sacola> PesquisarSacolas(int kit, int nivel);
        IList<Familia> ObterFamilias(int nivel);
        ValidationResult AddCrianca(int crianca);
        ValidationResult AddCrianca(Crianca crianca);
        ValidationResult AddFamilia(int familia);
        IList<Familia> ObterFamiliasDisponiveis();

    }
}
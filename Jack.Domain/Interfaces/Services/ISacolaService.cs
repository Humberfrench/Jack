using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ISacolaService : IServiceBase<Sacola>
    {
        ValidationResult AddCrianca(int crianca);
        byte[] GerarQrCode(int width, int height, Crianca crianca);
        byte[] GerarQrCode(int width, int height, Sacola sacola);
        byte[] GerarQrCode(int width, int height, int crianca);
        byte[] GerarQrCodeSacola(int width, int height, int sacola);
        ValidationResult Liberar(int id);
        IEnumerable<Familia> ObterFamiliasSacola();
        IEnumerable<SacolaValue> ObterSacolaParaImpressao(string sacolasNumero);
        IEnumerable<Sacola> ObterSacolasLivres(int ano, bool? liberado);
        IEnumerable<Sacola> ObterSacolasLivres(int nivel = 0, int liberado = 2);
        IEnumerable<Sacola> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, int familia = 0, string sexo = "", int kit = 0);
        IEnumerable<Sacola> ObterTodosPorNivel(int nivel, int liberado);
        List<Sacola> ProcessarSacolas(int ano);
        List<Sacola> ProcessarSacolas(int ano, bool todas);
        List<Familia> ProcessarSacolasEObterFamilias(int ano);
        List<Familia> ProcessarSacolasEObterFamilias(int ano, bool todas);
        void ValidarCrianca(Crianca crianca);
    }
}
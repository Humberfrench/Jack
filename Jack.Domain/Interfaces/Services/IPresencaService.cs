using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IPresencaService : IServiceBase<Presenca>
    {
        ValidationResult Gravar(int reuniaoId, int familiaId);
        ValidationResult Gravar(Reuniao reuniao, Familia familia);
        ValidationResult Excluir(int id);
        IEnumerable<Presenca> ObterFamiliaPorReuniao(int reuniao);
        IEnumerable<Presenca> ObterFamiliaLivrePorReuniao(int reuniao);
        List<Stats> ObterDadosPresenca(int familiaId);
        IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao);
        IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao, string letra);
        ValidationResult ProcessarPresencaGarantida();
        ValidationResult ProcessarPresencaRepresentantes();
    }
}
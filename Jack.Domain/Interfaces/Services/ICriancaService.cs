using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ICriancaService : IServiceBase<Crianca>
    {
        IEnumerable<Crianca> ObterCriancas(int familia);
        IEnumerable<Crianca> ObterCriancasSacola(int familia);
        ValidationResult Gravar(Crianca entity);
        ValidationResult GravarDados(int crianca, int calcado, string roupa, int tipoParentesco);
        ValidationResult Excluir(int id);
        bool ValidaCalcado(string sexo, int idade, string medidaIdade, int calcado);
        bool ValidaRoupa(string sexo, int idade, string medidaIdade, bool isCriancaGrande, string roupa);
        Crianca ValidaCrianca(CriancaValue criancaValue);
        ValidationResult AtualizaCriancasMaiores();
        ValidationResult AtualizaCriancas();
        ValidationResult AtualizaCriancas(bool todas);
        ValidationResult AtualizaCriancas(int familiaId);
        ValidationResult AtualizaCrianca(int id, bool gravar);
        ValidationResult AtualizaCrianca(Crianca crianca, bool gravar);
        Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false);
        IEnumerable<CriancaVestimenta> ObterDadosCriancaVestimentas(int familia);
    }
}
using Jack.Domain.Enum;
using Jack.Domain.Interfaces;
using Jack.Domain.Validations.Familia;
using Jack.DomainValidator;
using Jack.DomainValidator.Interfaces;
using Jack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Entity
{
    public class Familia : IEntidade, IValidator<Familia>
    {

        #region "Construtor"

        public Familia()
        {
            isValid = null;
            validationResult = new ValidationResult();
            nome = string.Empty;
            sacolinha = false;
            consistente = false;
            permiteExcedenteCriancas = false;
            permiteExcedenteRepresentantes = false;
            contato = string.Empty;
            estado = string.Empty;
            cidade = string.Empty;
            bairro = string.Empty;
            fake = false;
            enderecoFamilia = string.Empty;
            presencaJustificada = false;
            blackListPasso1 = false;
            blackListPasso2 = false;
            criancas = new List<Crianca>();
            sacolas = new List<Sacola>();
            presencas = new List<Presenca>();
            representantes = new List<Representante>();
            tratamento = new List<Tratamento>();
            dataAtualizacao = new DateTime();
            dataCriacao = new DateTime();
        }

        #endregion

        #region Fields

        private int codigo;
        private string nome;
        private bool ativo;
        private bool sacolinha;
        private bool consistente;
        private bool permiteExcedenteCriancas;
        private bool permiteExcedenteRepresentantes;
        private string contato;
        private string enderecoFamilia;
        private string bairro;
        private string cidade;
        private string estado;
        private bool fake;
        private bool presencaJustificada;
        private bool blackListPasso1;
        private bool blackListPasso2;
        private Nivel nivel;
        private StatusFamilia status;
        private IList<Crianca> criancas;
        private IList<Sacola> sacolas;
        private DateTime dataAtualizacao;
        private DateTime dataCriacao;
        private IList<Presenca> presencas;
        private IList<Representante> representantes;
        private IList<Tratamento> tratamento;
        private ValidationResult validationResult;
        private bool? isValid;
        #endregion

        #region Properties

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public virtual string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public virtual bool Sacolinha
        {
            get
            {
                return sacolinha;
            }
            set
            {
                sacolinha = value;
            }
        }

        public virtual bool Consistente
        {
            get
            {
                return consistente;
            }
            set
            {
                consistente = value;
            }
        }
        public virtual bool Ativo
        {
            get
            {
                return ativo;
            }
            set
            {
                ativo = value;
            }
        }

        public virtual bool PermiteExcedenteCriancas
        {
            get
            {
                return permiteExcedenteCriancas;
            }
            set
            {
                permiteExcedenteCriancas = value;
            }
        }

        public virtual bool PermiteExcedenteRepresentantes
        {
            get
            {
                return permiteExcedenteRepresentantes;
            }
            set
            {
                permiteExcedenteRepresentantes = value;
            }
        }

        public virtual string Contato
        {
            get
            {
                return contato;
            }
            set
            {
                contato = value;
            }
        }

        public virtual string EnderecoFamilia
        {
            get
            {
                return enderecoFamilia;
            }
            set
            {
                enderecoFamilia = value;
            }
        }
        public virtual string Bairro
        {
            get
            {
                return bairro;
            }
            set
            {
                bairro = value;
            }
        }
        public virtual string Cidade
        {
            get
            {
                return cidade;
            }
            set
            {
                cidade = value;
            }
        }
        public virtual string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public virtual bool Fake
        {
            get
            {
                return fake;
            }
            set
            {
                fake = value;
            }
        }

        public virtual bool PresencaJustificada
        {
            get
            {
                return presencaJustificada;
            }
            set
            {
                presencaJustificada = value;
            }
        }

        public virtual bool BlackListPasso1
        {
            get
            {
                return blackListPasso1;
            }
            set
            {
                blackListPasso1 = value;
            }
        }

        public virtual bool BlackListPasso2
        {
            get
            {
                return blackListPasso2;
            }
            set
            {
                blackListPasso2 = value;
            }
        }

        public virtual Nivel Nivel
        {
            get
            {
                return nivel;
            }
            set
            {
                nivel = value;
            }
        }

        public virtual StatusFamilia Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public virtual IList<Crianca> Criancas
        {
            get
            {
                return criancas;
            }
            set
            {
                criancas = value;
            }
        }

        public virtual IList<Sacola> Sacolas
        {
            get
            {
                return sacolas;
            }
            set
            {
                sacolas = value;
            }
        }

        public virtual DateTime DataAtualizacao
        {
            get
            {
                return dataAtualizacao;
            }
            set
            {
                dataAtualizacao = value;
            }
        }

        public virtual DateTime DataCriacao
        {
            get
            {
                return dataCriacao;
            }
            set
            {
                dataCriacao = value;
            }
        }

        public virtual IList<Presenca> Presencas
        {
            get
            {
                return presencas;
            }
            set
            {
                presencas = value;
            }
        }

        public virtual IList<Representante> Representantes
        {
            get
            {
                return representantes;
            }
            set
            {
                representantes = value;
            }
        }

        public virtual IList<Tratamento> Tratamento
        {
            get
            {
                return tratamento;
            }
            set
            {
                tratamento = value;
            }
        }

        #endregion

        #region Methods

        public virtual bool TemCriancas()
        {
            return Criancas.Any();
        }

        public virtual bool TemRepresentantes()
        {
            return Representantes.Any();
        }

        public virtual bool TemSacolas()
        {
            return Sacolas.Any();
        }

        public virtual bool TemCriancasMaiores()
        {
            var criancasMaiores = Criancas.Where(c => c.Status.Codigo == 8).ToList().Count;
            var totalCriancas = Criancas.ToList().Count;
            var totalCriancasNaoSacolas = Criancas.Where(c => !c.Status.PermiteSacola).ToList().Count;
            return (criancasMaiores == totalCriancas) || (totalCriancasNaoSacolas == totalCriancas);
        }

        public virtual bool TemDocumentacaoTodasCriancas()
        {
            var criancasDocoK = Criancas.Where(c => c.DocumentoOk).ToList().Count;
            var totalCriancas = Criancas.ToList().Count;
            return (criancasDocoK == totalCriancas);
        }

        public virtual bool FamiliaSemPresenca()
        {
            var numeroPresencas = Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList().Count;
            return (numeroPresencas == 0);
        }

        public virtual bool FamiliaSemPresenca(int ano)
        {
            var numeroPresencas = Presencas.Where(p => p.Reuniao.AnoCorrente == ano).ToList().Count;
            return (numeroPresencas == 0);
        }
        public virtual bool FamiliaBanida()
        {
            return Status.Codigo == EnumStatusFamilia.FamiliaBanidaPorProblemas.Int();
        }

        public virtual bool FamiliaComCriancasEmExcesso()
        {
            return Status.Codigo == EnumStatusFamilia.CriancasExcedido.Int();
        }

        public virtual bool FamiliaComTotalDeCriancasEmExcesso()
        {
            return Status.Codigo == EnumStatusFamilia.CriancasDaFamiliaEDoRepresentanteExcedido.Int();
        }

        public virtual bool FamiliaRepresentanteEmExcesso()
        {
            return Status.Codigo == EnumStatusFamilia.RepresentanteExcedido.Int();
        }

        public virtual bool FamiliaEmInvestigacao()
        {
            return Status.Codigo == EnumStatusFamilia.FamiliaEmInvestigacao.Int();
        }

        public virtual int QuantidadeTotalDeCriancas()
        {
            var totalCriancas = Criancas.Where(c => c.Status.PermiteSacola).ToList().Count;

            Representantes.ToList()
                          .ForEach(r => totalCriancas += r.FamiliaRepresentada.Criancas
                                        .Where(c => c.Status.PermiteSacola).ToList().Count);

            return totalCriancas;

        }

        public virtual bool FamiliaComCriancasDeRepresentanteExcedida(int limite)
        {
            return (limite < QuantidadeTotalDeCriancas());
        }

        #endregion                                       

        public virtual ValidationResult ValidationResult => validationResult;

        public virtual bool IsValid()
        {
            if (!isValid.HasValue)
            {
                validationResult = Validar(this);
                return validationResult.IsValid;
            }
            return isValid.Value;

        }

        public virtual ValidationResult Validar(Familia entity)
        {
            var entidadeValidate = new FamiliaEstaConsistente();
            validationResult = entidadeValidate.Validar(entity);
            return validationResult;
        }
    }
}

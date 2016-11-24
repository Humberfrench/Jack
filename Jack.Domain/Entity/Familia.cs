using Jack.DomainValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Familia : IEntidade
    {

        #region "Construtor"

        public Familia()
        {
            nome = string.Empty;
            sacolinha = false;
            consistente = false;
            permiteExcedente = false;
            contato = string.Empty;
            fake = false;
            presencaJustificada = false;
            blackListPasso1 = false;
            blackListPasso2 = false;
            criancas = new List<Crianca>();
            sacolas = new List<Sacola>();
            presencas = new List<Presenca>();
            representantes = new List<Representante>();
            dataAtualizacao = new DateTime();
            dataCriacao = new DateTime();
        }

        #endregion

        #region Fields

        private int codigo;
        private string nome;
        private bool sacolinha;
        private bool consistente;
        private bool permiteExcedente;
        private string contato;
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

        public virtual bool PermiteExcedente
        {
            get
            {
                return permiteExcedente;
            }
            set
            {
                permiteExcedente = value;
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
            var criancasMaiores = Criancas.Where(c => !c.DocumentoOk).ToList().Count;
            var totalCriancas = Criancas.ToList().Count;
            return (criancasMaiores == totalCriancas);
        }

        public virtual bool FamiliaSemPresenca()
        {
            var numeroPresencas = Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList().Count;
            return (numeroPresencas == 0);
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable]
    public class Criancas:BaseModel<Criancas>
    {

        public Criancas()
        {
            nome = string.Empty;
            idade = 0;
            DataNascimento = new DateTime();
            sexo = string.Empty;
            kit = new Kit();
            medidaIdade = string.Empty;
            calcado = 99;
            roupa = "99";
            isSacolinha = string.Empty;
            isConsistente = string.Empty;
            isNecessidadeEspecial = string.Empty;
            isMoralCrista = string.Empty;
            status = new Status();
            NomeFamilia = string.Empty;
            FamiliaRepresentante = string.Empty;
            DataAtualizacao = new DateTime();

        }

        private string nome;
        private int idade;
        private string medidaIdade;
        private string idadeNominalResumido;
        private DateTime dataNascimento;
        private string sexo;
        private int calcado;
        private string roupa;
        private int calcadoPadrao;
        private string roupaPadrao;
        private Kit kit;
        private string isSacolinha;
        private string isConsistente;
        private string isNecessidadeEspecial;
        private string isMoralCrista;
        private string isCriancaMaior;
        private Status status;
        private FamiliaCrianca familia;

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

        public virtual int Idade
        {
            get
            {
                return idade;
            }
            set
            {
                idade = value;
            }
        }

        public virtual string MedidaIdade
        {
            get
            {
                return medidaIdade;
            }
            set
            {
                medidaIdade = value;
            }
        }

        public virtual string IdadeNominalResumido
        {
            get
            {
                return idadeNominalResumido;
            }
            set
            {
                idadeNominalResumido = value;
            }
        }

        public virtual DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                dataNascimento = value;
            }
        }

        public virtual string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public virtual int Calcado
        {
            get
            {
                return calcado;
            }
            set
            {
                calcado = value;
            }
        }

        public virtual string Roupa
        {
            get
            {
                return roupa;
            }
            set
            {
                roupa = value;
            }
        }

        public virtual int CalcadoPadrao
        {
            get
            {
                return calcadoPadrao;
            }
            set
            {
                calcadoPadrao = value;
            }
        }

        public virtual string RoupaPadrao
        {
            get
            {
                return roupaPadrao;
            }
            set
            {
                roupaPadrao = value;
            }
        }

        public virtual Kit Kit
        {
            get
            {
                return kit;
            }
            set
            {
                kit = value;
            }
        }

        public virtual string IsSacolinha
        {
            get
            {
                return isSacolinha;
            }
            set
            {
                isSacolinha = value;
            }
        }

        public virtual string IsConsistente
        {
            get
            {
                return isConsistente;
            }
            set
            {
                isConsistente = value;
            }
        }

        public virtual string IsNecessidadeEspecial
        {
            get
            {
                return isNecessidadeEspecial;
            }
            set
            {
                isNecessidadeEspecial = value;
            }
        }

        public virtual string IsMoralCrista
        {
            get
            {
                return isMoralCrista;
            }
            set
            {
                isMoralCrista = value;
            }
        }

        public virtual string IsCriancaMaior
        {
            get
            {
                return isCriancaMaior;
            }
            set
            {
                isCriancaMaior = value;
            }
        }

        public virtual Status Status
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

        public virtual FamiliaCrianca Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }

        // locais de uso local
        public virtual string NomeFamilia { get; set; }
        public virtual string FamiliaRepresentante { get; set; }
        public virtual int FamiliaCodigo { get; set; }
        public virtual int FamiliaRepresentanteCodigo { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual int StatusCodigo
        {
            get { return Status.Codigo; }
        }
        public virtual string StatusNome
        {
            get { return Status.Descricao; }
        }

        public virtual string DataCriacaoString
        {
            get { return DataCriacao.ToShortDateString(); }
        }

        public virtual string DataCriacaoFormated
        {
            get { return DataCriacao.Day.ToString("00") + "/" + DataCriacao.Month.ToString("00") + "/" + DataCriacao.Year.ToString("0000"); }
        }
        public virtual string DataAtualizacaoString
        {
            get { return DataAtualizacao.ToShortDateString(); }
        }

        public virtual string DataAtualizacaoFormated
        {
            get { return DataAtualizacao.Day.ToString("00") + "/" + DataAtualizacao.Month.ToString("00") + "/" + DataAtualizacao.Year.ToString("0000"); }
        }

        public virtual string IdadeCrianca
        {
            get
            {
                if (MedidaIdade == "A")
                {
                    return Idade.ToString() + " Anos";
                }
                else {
                    return Idade.ToString() + " Meses";
                }
            }
        }

        public virtual string Sacolinha
        {
            get
            {
                if (IsSacolinha == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

        public virtual string Consistente
        {
            get
            {
                if (IsConsistente == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }
        public virtual string CriancaMaior
        {
            get
            {
                if (IsCriancaMaior == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }
        public virtual string DataNascimentoString
        {
            get { return DataNascimento.ToShortDateString(); }
        }

        public virtual string DataFormated
        {
            get { return DataNascimento.Day.ToString("00") + "/" + DataNascimento.Month.ToString("00") + "/" + DataNascimento.Year.ToString("0000"); }
        }

    }

}

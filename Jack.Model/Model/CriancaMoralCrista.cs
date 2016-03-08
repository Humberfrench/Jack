using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    public class CriancaMoralCrista : BaseModel<CriancaMoralCrista>
    {
        private int codigoCrianca;
        private string nome;
        private DateTime dataNascimento;
        private string sexo;
        private string problemaSaude;
        private string alergia;
        private string tratamento;
        private string medo;
        private string isCalmo;
        private string isAgitado;
        private string isNervoso;
        private string isAnsioso;
        private string isTimido;
        private string isLeitura;
        private string isMusica;
        private string isDesenho;
        private string isDanca;
        private string isPintura;
        private string isEscrever;
        private string isVerTv;
        private string isOutros;
        private string outros;
        private string observacao;
        private string isAtivo;
        private IList<Responsavel> responsavel;

        public virtual int CodigoCrianca
        {
            get
            {
                return codigoCrianca;
            }
            set
            {
                codigoCrianca = value;
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
        public virtual string ProblemaSaude
        {
            get
            {
                return problemaSaude;
            }
            set
            {
                problemaSaude = value;
            }
        }
        public virtual string Alergia
        {
            get
            {
                return alergia;
            }
            set
            {
                alergia = value;
            }
        }
        public virtual string Tratamento
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
        public virtual string Medo
        {
            get
            {
                return medo;
            }
            set
            {
                medo = value;
            }
        }
        public virtual string IsCalmo
        {
            get
            {
                return isCalmo;
            }
            set
            {
                isCalmo = value;
            }
        }
        public virtual string IsAgitado
        {
            get
            {
                return isAgitado;
            }
            set
            {
                isAgitado = value;
            }
        }
        public virtual string IsNervoso
        {
            get
            {
                return isNervoso;
            }
            set
            {
                isNervoso = value;
            }
        }
        public virtual string IsAnsioso
        {
            get
            {
                return isAnsioso;
            }
            set
            {
                isAnsioso = value;
            }
        }
        public virtual string IsTimido
        {
            get
            {
                return isTimido;
            }
            set
            {
                isTimido = value;
            }
        }
        public virtual string IsLeitura
        {
            get
            {
                return isLeitura;
            }
            set
            {
                isLeitura = value;
            }
        }
        public virtual string IsMusica
        {
            get
            {
                return isMusica;
            }
            set
            {
                isMusica = value;
            }
        }
        public virtual string IsDesenho
        {
            get
            {
                return isDesenho;
            }
            set
            {
                isDesenho = value;
            }
        }
        public virtual string IsDanca
        {
            get
            {
                return isDanca;
            }
            set
            {
                isDanca = value;
            }
        }
        public virtual string IsPintura
        {
            get
            {
                return isPintura;
            }
            set
            {
                isPintura = value;
            }
        }
        public virtual string IsEscrever
        {
            get
            {
                return isEscrever;
            }
            set
            {
                isEscrever = value;
            }
        }
        public virtual string IsVerTv
        {
            get
            {
                return isVerTv;
            }
            set
            {
                isVerTv = value;
            }
        }
        public virtual string IsOutros
        {
            get
            {
                return isOutros;
            }
            set
            {
                isOutros = value;
            }
        }
        public virtual string Outros
        {
            get
            {
                return outros;
            }
            set
            {
                outros = value;
            }
        }
        public virtual string Observacao
        {
            get
            {
                return observacao;
            }
            set
            {
                observacao = value;
            }
        }
        public virtual string IsAtivo
        {
            get
            {
                return isAtivo;
            }
            set
            {
                isAtivo = value;
            }
        }
        public virtual  IList<Responsavel> Responsavel
        {
            get
            {
                return responsavel;
            }
            set
            {
                responsavel = value;
            }
        }

    }
}

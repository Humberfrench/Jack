using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable]
    public class Criancas
    {

        public Criancas()
        {
            Codigo = 0;
            Nome = string.Empty;
            Idade = 0;
            DataNascimento = new DateTime();
            Sexo = string.Empty;
            Kit = 0;
            MedidaIdade = string.Empty;
            Calcado = 99;
            Roupa = "99";
            IsSacolinha = string.Empty;
            IsConsistente = string.Empty;
            IsNecessidadeEspecial = string.Empty;
            IsMoralCrista = string.Empty;
            Status = new Status();
            Familia = string.Empty;
            FamiliaRepresentante = string.Empty;
            DataAtualizacao = new DateTime();

        }

        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual int Idade { get; set; }
        public virtual string MedidaIdade { get; set; }
        public virtual string IdadeNominalResumido { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Sexo { get; set; }
        public virtual int Calcado { get; set; }
        public virtual string Roupa { get; set; }
        public virtual int CalcadoPadrao { get; set; }
        public virtual string RoupaPadrao { get; set; }
        public virtual int Kit { get; set; }
        public virtual string IsSacolinha { get; set; }
        public virtual string IsConsistente { get; set; }
        public virtual string IsNecessidadeEspecial { get; set; }
        public virtual string IsMoralCrista { get; set; }
        public virtual string IsCriancaMaior { get; set; }
        public virtual Model.Status Status { get; set; }
        public virtual string Familia { get; set; }
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

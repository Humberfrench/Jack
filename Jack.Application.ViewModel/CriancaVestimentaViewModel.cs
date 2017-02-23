using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class CriancaVestimentaViewModel
    {
        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }

        [Display(Name = "Parentesco")]
        public virtual int TipoParentescoId { get; set; }

        [Display(Name = "Parentesco")]
        public virtual string TipoParentesco { get; set; }

        [Display(Name = "Família")]
        public virtual string Familia { get; set; }

        [Display(Name = "Idade")]
        public virtual int Idade { get; set; }

        [Display(Name = "Medida Idade ")]
        public virtual string MedidaIdade { get; set; }

        [Display(Name = "Sexo")]
        public virtual string Sexo { get; set; }

        [Display(Name = "Calcado")]
        public virtual int Calcado { get; set; }

        [Display(Name = "Roupa")]
        public virtual string Roupa { get; set; }

        [Display(Name = "Roupa")]
        public virtual int CalcadoPadrao { get; set; }

        [Display(Name = "Calcado")]
        public virtual string RoupaPadrao { get; set; }

        [Display(Name = "Necessidade Especial")]
        public virtual bool NecessidadeEspecial { get; set; }

        [Display(Name = "Crianca Grande?")]
        public virtual bool CriancaGrande { get; set; }

        [Display(Name = "Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeNominal { get; set; }

        [Display(Name = "Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeNominalReduzida { get; set; }

        [Display(Name = "Status")]
        public virtual string Status { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class CriancaViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }

        public virtual FamiliaViewModel Familia { get; set; }

        [Display(Name = "Idade")]
        public virtual int Idade { get; set; }

        [Display(Name = "Medida Idade ")]
        public virtual string MedidaIdade { get; set; }

        [Display(Name = "Data Nascimento")]
        public virtual DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        public virtual string Sexo { get; set; }

        [Display(Name = "Calcado")]
        public virtual int Calcado { get; set; }

        [Display(Name = "Roupa")]
        public virtual string Roupa { get; set; }

        public virtual KitViewModel Kit { get; set; }

        [Display(Name = "Tipo de Parentesco")]
        public  virtual TipoParentescoViewModel TipoParentesco { get; set; }

        public virtual bool Sacolinha { get; set; }

        public virtual bool Consistente { get; set; }

        [Display(Name = "Necessidade Especial")]
        public virtual bool NecessidadeEspecial { get; set; }

        [Display(Name = "Moral Crista")]
        public virtual bool MoralCrista { get; set; }

        [Display(Name = "Crianca Grande?")]
        public virtual bool CriancaGrande { get; set; }

        [Display(Name = "Documento Ok?")]
        public virtual bool DocumentoOk { get; set; }

        [Display(Name = "Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeNominal { get; set; }

        [Display(Name = "Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeNominalReduzida { get; set; }

        [Display(Name = "Status")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual StatusCriancaViewModel Status { get; set; }

        public virtual DateTime DataAtualizacao { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual SacolaViewModel Sacola { get; set; }

    }

}

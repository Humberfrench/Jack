using System;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class ColaboradorCriancaViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Colaborador")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual ColaboradorViewModel Colaborador { get; set; }

        [Display(Name = "Criança")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual CriancaViewModel Crianca { get; set; }

        [Display(Name = "Ano")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Ano { get; set; }

        [Display(Name = "Devolvida")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool Devolvida { get; set; }

         [Display(Name = "Data Criação")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual DateTime DataCriacao { get; set; }

        [Display(Name = "Data Devolução")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual DateTime? DataDevolucao  { get; set; }

    }
}

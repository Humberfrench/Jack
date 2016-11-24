using System;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{

    public class TipoItemViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [MaxLength(50)]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Opcional")]
        [DisplayFormat(NullDisplayText = "0")]
        public virtual bool Opcional { get; set; }

    }
}

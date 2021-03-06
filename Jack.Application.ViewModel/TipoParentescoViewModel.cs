﻿using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class TipoParentescoViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Parentesco")]
        [Required(ErrorMessage = "Parentesco é obrigatório.")]
        [MaxLength(50)]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Opcional")]
        [DisplayFormat(NullDisplayText = "Não")]
        public virtual bool Parente { get; set; }

        [Display(Name = "Grau de Parentesco")]
        [Required(ErrorMessage = "Grau de Parentesco é obrigatório.")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int GrauParentesco { get; set; }
    }
}
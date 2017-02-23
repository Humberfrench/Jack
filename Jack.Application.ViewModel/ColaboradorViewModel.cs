using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class ColaboradorViewModel 
    {

        public virtual IList<ColaboradorCriancaViewModel> Criancas { get; set; }
        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Nome")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Nome { get; set; }

        [Display(Name = "Telefone")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Telefone { get; set; }

        [Display(Name = "Celular")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Celular { get; set; }

        [Display(Name = "C.P.F.")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Cpf { get; set; }

        [Display(Name = "E-Mail")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Email { get; set; }

        [Display(Name = "Ano de Notificacao")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int AnoNotificacao { get; set; }

    }
}

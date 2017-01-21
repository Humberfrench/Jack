using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class KitItemViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "TipoItem")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual TipoItemViewModel TipoItem { get; set; }

        [Display(Name = "Ordem")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Ordem { get; set; }

        [Display(Name = "Observação")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Observacao { get; set; }

        [Display(Name = "Kit")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual KitViewModel Kit { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class RepresentanteViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Ativo")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool Ativo { get; set; }

        [Display(Name = "Familia Representante")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual FamiliaViewModel FamiliaRepresentante { get; set; }

        [Display(Name = "Familia Representada")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual FamiliaViewModel FamiliaRepresentada { get; set; }

    }
}
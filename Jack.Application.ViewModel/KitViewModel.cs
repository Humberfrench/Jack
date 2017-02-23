using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class KitViewModel 
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Descrição")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Idade Mínima")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual float IdadeMinima { get; set; }

        [Display(Name = "Idade Máxima")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual float IdadeMaxima { get; set; }

        [Display(Name = "Sexo")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Sexo { get; set; }

        [Display(Name = "Necessidade Especial")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool NecessidadeEspecial { get; set; }

        [Display(Name = "Crianças")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<CriancaViewModel> Criancas { get; set; }

        [Display(Name = "Items")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<KitItemViewModel> Items { get; set; }

    }
}

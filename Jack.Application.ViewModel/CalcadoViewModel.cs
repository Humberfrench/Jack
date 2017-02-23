
using Jack.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class CalcadoViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Número")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Numero { get; set; }

        [Display(Name = "Sexo")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Sexo {get; set;}

        [Display(Name = "Início")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Inicio {get; set;}

        [Display(Name = "Fim")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Fim {get; set;}

        [Display(Name = "Medida Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string MedidaIdade { get; set; }

        [Display(Name = "Idade Inicial")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeInicial
        {
            get
            {
                return string.Format("{0} {1}", Inicio, MedidaIdade.ToMedidaIdade());
            }
        }

        [Display(Name = "Idade Final")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeFinal
        {
            get
            {
                return string.Format("{0} {1}", Fim, MedidaIdade.ToMedidaIdade());
            }
        }


    }
}


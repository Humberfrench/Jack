using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.Extensions;

namespace Jack.Application.ViewModel
{
    public class RoupaViewModel
    {

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Descrição")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Tamanho")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Tamanho { get; set; }

        [Display(Name = "Tamanho Maior")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string TamanhoMaior { get; set; }

        [Display(Name = "Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Idade { get; set; }

        [Display(Name = "MedidaIdade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string MedidaIdade { get; set; }

        [Display(Name = "Idade")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string IdadeCompleta
        {
            get
            {
                return string.Format("{0} {1}", Idade, MedidaIdade.ToMedidaIdade());
            }
        }

    }

}

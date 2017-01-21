using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class NivelViewModel
    {
        public NivelViewModel()
        {
            familias = new List<FamiliaViewModel>();
        }

        private IList<FamiliaViewModel> familias;

        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Nome")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Descricao { get; set; }

        [Display(Name = "% Inicial")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual float PercentualInicial { get; set; }

        [Display(Name = "% Final")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual float PercentualFinal { get; set; }

        [Display(Name = "Sacola Garantida")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool SacolaGarantida { get; set; }

        [Display(Name = "Lista de Espera")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool ListaDeEspera { get; set; }

        [Display(Name = "Não Gerar Sacola")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool NuncaGerarSacola { get; set; }

        public virtual IList<FamiliaViewModel> Familias
        {
            get
            {
                return familias;
            }
            set
            {
                familias = value;
            }
        }

    }


}
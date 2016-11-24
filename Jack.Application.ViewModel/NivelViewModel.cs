using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class NivelViewModel
    {
        public NivelViewModel()
        {
            familias = new List<FamiliaViewModel>();
        }

        private IList<FamiliaViewModel> familias;

        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual float PercentualIncial { get; set; }
        public virtual float PercentualFinal { get; set; }
        public virtual bool SacolaGarantida { get; set; }
        public virtual bool ListaDeEspera { get; set; }
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
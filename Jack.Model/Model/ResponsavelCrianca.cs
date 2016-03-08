using Jack.Model;
using System.Collections.Generic;

namespace Jack.Data.Map
{
    public class ResponsavelCrianca : BaseModel<ResponsavelCrianca>
    {
        #region "Construtor"

        public ResponsavelCrianca()
        {
            criancas = new List<CriancaMoralCrista>();
            crianca = new CriancaMoralCrista();
            responsavel = new Responsavel();
        }

        #endregion

        private IList<CriancaMoralCrista> criancas;
        private CriancaMoralCrista crianca;
        private Responsavel responsavel;

        public virtual CriancaMoralCrista Crianca
        {
            get
            {
                return crianca;
            }
            set
            {
                crianca = value;
            }
        }

        public virtual Responsavel Responsavel
        {
            get
            {
                return responsavel;
            }
            set
            {
                responsavel = value;
            }
        }

        public virtual IList<CriancaMoralCrista> Criancas
        {
            get
            {
                return criancas;
            }
            set
            {
                criancas = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class FamiliaCrianca : BaseModel<FamiliaCrianca>
    {

        #region "Construtor"

        public FamiliaCrianca()
        {
            criancas = new List<Criancas>();
            crianca = new Criancas();
            familia = new Familia();
        }

        #endregion

        private IList<Criancas> criancas;
        private Criancas crianca;
        private Familia familia;

        public virtual Criancas Crianca
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
            
        public virtual Familia Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }

        public virtual IList<Criancas> Criancas
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

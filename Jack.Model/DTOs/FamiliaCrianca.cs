using System;

namespace Jack.Model
{
    [Serializable()]
    public class FamiliaCrianca
    {

        #region "Construtor"

        public FamiliaCrianca()
        {
            Crianca = 0;
            Familia = 0;
        }


        public FamiliaCrianca(int intCrianca, int intFamilia)
        {
            Crianca = intCrianca;
            Familia = intFamilia;
        }

        #endregion

        public virtual int Crianca { get; set; }
        public virtual int Familia { get; set; }

    }

}

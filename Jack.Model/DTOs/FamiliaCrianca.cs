using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class FamiliaCrianca
    {

        #region "Construtor"

        public FamiliaCrianca()
        {
            Criancas = new List<Criancas>();
            Crianca = new Criancas();
            Familia = new Familia();
        }


        //public FamiliaCrianca(int intCrianca, int intFamilia)
        //{
        //    Crianca = intCrianca;
        //    Familia = intFamilia;
        //}

        #endregion

        public virtual Criancas Crianca { get; set; }
        public virtual Familia Familia { get; set; }

        public virtual List<Criancas> Criancas { get; set; }

    }

}

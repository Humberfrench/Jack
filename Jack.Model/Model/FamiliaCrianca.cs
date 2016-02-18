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
            criancas = new List<Criancas>();
            crianca = new Criancas();
            familia = new Familia();
        }

        #endregion

        private List<Criancas> criancas;
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

        public virtual List<Criancas> Criancas
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

        public override bool Equals(object obj)
        {
            var other = obj as FamiliaCrianca;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Familia == other.Familia &&
                Crianca == other.Crianca;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Familia.GetHashCode();
                hash = (hash * 31) ^ Crianca.GetHashCode();

                return hash;
            }
        }

    }

}

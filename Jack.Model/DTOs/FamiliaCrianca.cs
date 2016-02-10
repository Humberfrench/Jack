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
            _criancas = new List<Criancas>();
            _crianca = new Criancas();
            _familia = new Familia();
        }

        #endregion

        private List<Criancas> _criancas;
        private Criancas _crianca;
        private Familia _familia;


        public virtual Criancas Crianca
        {
            get
            {
                return _crianca;
            }
            set
            {
                _crianca = value;
            }
        }
            
        public virtual Familia Familia
        {
            get
            {
                return _familia;
            }
            set
            {
                _familia = value;
            }
        }


        public virtual List<Criancas> Criancas
        {
            get
            {
                return _criancas;
            }
            set
            {
                _criancas = value;
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

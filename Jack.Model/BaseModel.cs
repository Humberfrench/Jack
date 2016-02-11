using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    public abstract class BaseModel<T> : IEntidade where T : IEntidade
    {

        private int codigo;

        public BaseModel()
        {
            codigo = 0;
        }

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                string nomeParametro = obj.GetType().Name.Replace("Proxy", String.Empty);
                string nomeAtual = typeof(T).Name.Replace("Proxy", String.Empty);

                if (nomeParametro != null && nomeParametro.StartsWith(nomeAtual)) // Alteração para funcionar com mock de objetos
                {
                    if (hasSameIdentifierAs((T)obj))
                    {
                        // Both entities are persistent so we are able to
                        // compare the identifiers.
                        return true;
                    }
                    else if (hasDifferentPersistanceContextAs((T)obj))
                    {
                        // One entity is transient one is
                        // persistence so that cannot be equal.
                        return false;
                    }
                    else
                    {
                        // Neihter Entity has an Identity.
                        return false;
                    }
                }
            }

            return false;
        }

        private bool hasSameIdentifierAs(T entityToCompare)
        {
            if (!(Transitorio() && entityToCompare.Transitorio()))
                return this.Codigo == entityToCompare.Codigo;
            else
                return false;
        }

        private bool hasDifferentPersistanceContextAs(T entityToCompare)
        {
            return !(Transitorio() == entityToCompare.Transitorio());
        }

        public override int GetHashCode()
        {
            if (Transitorio())
                return this.GetType().FullName.GetHashCode();
            else
                return String.Format("{0}{1}", this.GetType().FullName, this.Codigo.ToString()).GetHashCode();
        }

        public virtual bool Transitorio()
        {
            return Codigo == 0;
        }
    }
}

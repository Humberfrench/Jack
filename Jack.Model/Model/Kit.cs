using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Kit
    {

        #region "Construtor"

        public Kit()
        {
            Codigo = 0;
            Descricao = string.Empty;
            IdadeMinima = 0;
            IdadeMaxima = 0;
            Sexo = string.Empty;
            IsNecessidadeEspecial = string.Empty;
        }


        #endregion

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int IdadeMinima { get; set; }
        public virtual int IdadeMaxima { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string IsNecessidadeEspecial { get; set; }

        public virtual string IdadeMinimaDesc
        {
            get { return IdadeMinima.ToString() + " Anos"; }
        }
        public virtual string IdadeMaximaDesc
        {
            get { return IdadeMaxima.ToString() + " Anos"; }
        }
        public virtual string SexoDesc
        {
            get
            {
                if (Sexo == "F")
                {
                    return "Feminino";
                }
                else {
                    return "Masculino";
                }
            }
        }

    }
}

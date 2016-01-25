using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class ColaboradorCrianca
    {

        #region "Construtor"

        public ColaboradorCrianca()
        {
            Crianca = 0;
            Colaborador = 0;
        }


        #endregion

        public virtual int Codigo { get; set; }
        public virtual int Colaborador { get; set; }
        public virtual int Crianca { get; set; }
        public virtual int Ano { get; set; }
        public virtual int NumeroSacola { get; set; }
        public virtual string IsDevolvida { get; set; }
        public virtual string NomeCrianca { get; set; }
        public virtual string NomeColaborador { get; set; }

        public virtual int NumeroIdade { get; set; }
        public virtual string MedidaIdade { get; set; }

        public virtual int Calcado { get; set; }
        public virtual string Roupa { get; set; }

        public virtual string Idade
        {
            get
            {
                if (MedidaIdade == "A")
                {
                    return NumeroIdade.ToString() + " Anos";
                }
                else {
                    return NumeroIdade.ToString() + " Meses";
                }
            }
        }

    }
}

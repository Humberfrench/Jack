using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Presenca
    {

        #region "Construtor"

        public Presenca()
        {
            Familia = new List<Familia>();
            Reuniao = new List<Reuniao>();
            Codigo = 0;
        }

        #endregion

        public virtual int Codigo { get; set; }
        public virtual List<Familia> Familia { get; set; }
        public virtual List<Reuniao> Reuniao { get; set; }

    }
}

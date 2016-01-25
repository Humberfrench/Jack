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
            Familia = 0;
            Reuniao = 0;
            Codigo = 0;
        }

        #endregion

        public virtual int Codigo { get; set; }
        public virtual int Familia { get; set; }
        public virtual int Reuniao { get; set; }

    }
}

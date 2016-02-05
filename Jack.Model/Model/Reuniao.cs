using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Reuniao
    {

        public virtual int Codigo { get; set; }
        public virtual int Ano { get; set; }
        public virtual int AnoCorrente { get; set; }
        public virtual System.DateTime Data { get; set; }
        public virtual List<Familia> Familia { get; set; }

        public virtual string DataFormated
        {
            get { return Data.Day.ToString("00") + "/" + Data.Month.ToString("00") + "/" + Data.Year.ToString("0000"); }
        }

    }
}

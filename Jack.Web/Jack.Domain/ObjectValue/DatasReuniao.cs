using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Domain.ObjectValue
{
    public class DatasReuniao
    {
        public DatasReuniao()
        {
            Datas = new List<DateTime>();
        }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public List<DateTime> Datas { get; set; }
    }
}

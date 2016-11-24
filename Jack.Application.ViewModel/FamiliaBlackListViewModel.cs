using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application.ViewModel
{
    public class FamiliaBlackListViewModel
    {

        public virtual int Codigo { get; set; }
        public FamiliaViewModel Familia { get; set; }
        public int Ano { get; set; }

    }
}

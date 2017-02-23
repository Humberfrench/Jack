using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Library
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class BreadCrumbETitulo
    {
        public string Titulo { get; set; }

        public List<BreadCrumb> BreadCrumbs { get; set; }
    }

}

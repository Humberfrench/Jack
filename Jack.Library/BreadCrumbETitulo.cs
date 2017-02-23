
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

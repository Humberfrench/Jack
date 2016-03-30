using System;

namespace Jack.DTO
{
    [Serializable()]
    public class CriancasInconsistentes 
    {

        public virtual string NomeMae { get; set; }
        public virtual string DescricaoStatus { get; set; }
        public virtual string DescricaoIdade { get; set; }

    }
}

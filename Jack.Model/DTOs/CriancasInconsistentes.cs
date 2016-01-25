using System;

namespace Jack.Model
{
    [Serializable()]
    public class CriancasInconsistentes : Criancas
    {

        public virtual string NomeMae { get; set; }
        public virtual string DescricaoStatus { get; set; }
        public virtual string DescricaoIdade { get; set; }

    }
}

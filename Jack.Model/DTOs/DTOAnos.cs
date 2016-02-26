namespace Jack.Model.DTOs
{
    public class DTOAnos
    {
        public DTOAnos()
        {
            valor = string.Empty;
            descricao = string.Empty;
        }
        public DTOAnos(string pValue, string pDescricao) :this()
        {
            valor = pValue;
            descricao = pDescricao;
        }

        private string valor;
        private string descricao;

        public virtual string Value
        {
            get
            {
                return valor;
            }
            set
            {
                value = valor;
            }
        }
        public virtual string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }

    }
}

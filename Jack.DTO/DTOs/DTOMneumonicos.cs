namespace Jack.DTO
{
    public class DTOMneumonicos
    {
        public DTOMneumonicos()
        {
            valor = string.Empty;
        }

        public DTOMneumonicos(string pValor)
        {
            valor = pValor;
        }

        private string valor;
        public virtual string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
    }
}

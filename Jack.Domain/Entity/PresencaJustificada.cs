using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class PresencaJustificada : IEntidade
    {
        public PresencaJustificada()
        {
            codigo = 0;
            familia = new Familia();
            ativo = false;
        }

        private int codigo;
        private Familia familia;
        private bool ativo;

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public virtual Familia Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }

        public virtual bool Ativo
        {
            get
            {
                return ativo;
            }
            set
            {
                ativo = value;
            }
        }

    }
}

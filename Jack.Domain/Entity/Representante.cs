using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Representante  : IEntidade
    {
        #region "Construtor"

        public Representante() 
        {
            codigo = 0;
            ativo = false;
        }

        #endregion

        private int codigo;
        private bool ativo;
        private Familia familiaRepresentante;
        private Familia familiaRepresentada;

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

        public virtual Familia FamiliaRepresentante
        {
            get
            {
                return familiaRepresentante;
            }
            set
            {
                familiaRepresentante = value;
            }
        }

        public virtual Familia FamiliaRepresentada
        {
            get
            {
                return familiaRepresentada;
            }
            set
            {
                familiaRepresentada = value;
            }
        }
    }
}
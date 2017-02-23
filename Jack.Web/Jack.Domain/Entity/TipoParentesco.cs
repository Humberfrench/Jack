using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class TipoParentesco :IEntidade
    {

        private int codigo;
        private bool parente;
        private string descricao;
        private int grauParentesco;

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

        public virtual bool Parente
        {
            get
            {
                return parente;
            }
            set
            {
                parente = value;
            }
        }
        public virtual int GrauParentesco
        {
            get
            {
                return grauParentesco;
            }
            set
            {
                grauParentesco = value;
            }
        }


    }
}
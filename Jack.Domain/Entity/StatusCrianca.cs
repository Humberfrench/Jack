using Jack.Domain.Interfaces;
using System.Collections.Generic;

namespace Jack.Domain.Entity
{
    public class StatusCrianca : IEntidade
    {
 
        #region "Construtor"

        public StatusCrianca() :base()
        {
            codigo = 0;
            descricao = string.Empty;
            permiteSacola = false;
            criancas = new List<Crianca>();
        }

        public StatusCrianca(string strDescricao) :this()
        {
            codigo = 0;
            descricao = strDescricao;
            permiteSacola = false;
            criancas = new List<Crianca>();
        }

        public StatusCrianca(int intCodigo, string strDescricao) : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = false;
            familias = new List<Familia>();
            criancas = new List<Crianca>();
        }

        public StatusCrianca(int intCodigo, string strDescricao, bool pPermiteSacola)
            : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = pPermiteSacola;
            familias = new List<Familia>();
            criancas = new List<Crianca>();
        }

        #endregion

        #region "Fields"
        private int codigo;
        private string descricao;
        private bool permiteSacola;
        private IList<Familia> familias;
        private IList<Crianca> criancas;
        #endregion

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

        public virtual bool PermiteSacola
        {
            get
            {
                return permiteSacola;
            }
            set
            {
                permiteSacola = value;
            }
        }

        public virtual IList<Crianca> Criancas
        {
            get
            {
                return criancas;
            }
            set
            {
                criancas = value;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using Jack.Library.Extensions;

namespace Jack.Model
{
    [Serializable()]
    public class Kit : BaseModel<Kit>
    {

        #region "Construtor"

        public Kit() : base()
        {
            Codigo = 0;
            descricao = string.Empty;
            idadeMinima = 0;
            idadeMaxima = 0;
            sexo = string.Empty;
            isNecessidadeEspecial = string.Empty;
            items = new List<KitItem>();
            criancas = new List<Criancas>();
        }

        public Kit(int intCodigo) : this()
        {
            Codigo = intCodigo;
            descricao = string.Empty;
            idadeMinima = 0;
            idadeMaxima = 0;
            sexo = string.Empty;
            isNecessidadeEspecial = string.Empty;
            items = new List<KitItem>();
            criancas = new List<Criancas>();
        }

        public Kit(int pCodigo, string pDescricao, 
                   float pIdadeMinima, float pIdadeMaxima, 
                   string pSexo, string pIsNecessidadeEspecial) : this()
        {
            Codigo = pCodigo;
            descricao = pDescricao;
            idadeMinima = pIdadeMinima;
            idadeMaxima = pIdadeMaxima;
            sexo = pSexo;
            isNecessidadeEspecial = pIsNecessidadeEspecial;
            items = new List<KitItem>();
            criancas = new List<Criancas>();
        }

        #endregion

        private string descricao;
        private float idadeMinima;
        private float idadeMaxima;
        private string sexo;
        private string sexoDesc;
        private string isNecessidadeEspecial;
        private string necessidadeEspecial;
        private IList<KitItem> items;
        private IList<Criancas> criancas;


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
        public virtual float IdadeMinima
        {
            get
            {
                return idadeMinima;
            }
            set
            {
                idadeMinima = value;
            }
        }
        public virtual float IdadeMaxima
        {
            get
            {
                return idadeMaxima;
            }
            set
            {
                idadeMaxima = value;
            }
        }
        public virtual string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
                sexoDesc = sexo.ToSexo();
            }
        }
        public virtual string IsNecessidadeEspecial
        {
            get
            {
                return isNecessidadeEspecial;
            }
            set
            {
                necessidadeEspecial = isNecessidadeEspecial.ToSimNao();
                isNecessidadeEspecial = value;
            }
        }
        public virtual IList<Criancas> Criancas
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
        public virtual IList<KitItem> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public virtual string NecessidadeEspecial
        {
            get
            {
                return necessidadeEspecial;
            }
        }

        public virtual string IdadeMinimaDesc
        {
            get { return idadeMinima.ToString() + " Anos"; }
        }

        public virtual string IdadeMaximaDesc
        {
            get { return idadeMaxima.ToString() + " Anos"; }
        }
        public virtual string SexoDesc
        {
            get
            {
                return sexoDesc;
            }
        }

    }
}

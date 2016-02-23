using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Kit : BaseModel<Kit>
    {

        #region "Construtor"

        public Kit()
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

        public Kit(int intCodigo)
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

        public Kit(int pCodigo, string pDescricao, int pIdadeMinima, int pIdadeMaxima, string pSexo, string pIsNecessidadeEspecial)
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
        private int idadeMinima;
        private int idadeMaxima;
        private string sexo;
        private string isNecessidadeEspecial;
        private List<KitItem> items;
        private List<Criancas> criancas;


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
        public virtual int IdadeMinima
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
        public virtual int IdadeMaxima
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
                isNecessidadeEspecial = value;
            }
        }
        public virtual List<Criancas> Criancas
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
        public virtual List<KitItem> Items
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
                if (sexo == "F")
                {
                    return "Feminino";
                }
                else {
                    return "Masculino";
                }
            }
        }

    }
}

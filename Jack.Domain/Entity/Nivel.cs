using System.Collections.Generic;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Nivel : IEntidade
    {

        public Nivel()
        {
            codigo = 0;
            nome = string.Empty;
            descricao = string.Empty;
            percentualIncial = 0;
            percentualFinal = 0;
            sacolaGarantida = false;
            listaDeEspera = false;
            nuncaGerarSacola = false;
            familias = new List<Familia>();
        }

        #region Fields

        private int codigo;
        private string nome;
        private string descricao;
        private float percentualIncial;
        private float percentualFinal;
        private bool sacolaGarantida;
        private bool listaDeEspera;
        private bool nuncaGerarSacola;
        private IList<Familia> familias;

        #endregion

        #region Propriedades
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

        public virtual string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
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

        public virtual float PercentualIncial
        {
            get
            {
                return percentualIncial;
            }
            set
            {
                percentualIncial = value;
            }
        }

        public virtual float PercentualFinal
        {
            get
            {
                return percentualFinal;
            }
            set
            {
                percentualFinal = value;
            }
        }

        public virtual bool SacolaGarantida
        {
            get
            {
                return sacolaGarantida;
            }
            set
            {
                sacolaGarantida = value;
            }
        }

        public virtual bool ListaDeEspera
        {
            get
            {
                return listaDeEspera;
            }
            set
            {
                listaDeEspera = value;
            }
        }

        public virtual bool NuncaGerarSacola
        {
            get
            {
                return nuncaGerarSacola;
            }
            set
            {
                nuncaGerarSacola = value;
            }
        }

        public virtual IList<Familia> Familias
        {
            get
            {
                return familias;
            }
            set
            {
                familias = value;
            }
        }

        #endregion


    }


}
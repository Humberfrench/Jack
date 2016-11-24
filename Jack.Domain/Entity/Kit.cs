using System;
using System.Collections.Generic;
using Jack.Domain.Interfaces;
using Jack.Extensions;

namespace Jack.Domain.Entity
{
    public class Kit : IEntidade 
    {

        #region "Construtor"

        public Kit() 
        {
            codigo = 0;
            descricao = string.Empty;
            idadeMinima = 0;
            idadeMaxima = 0;
            sexo = string.Empty;
            necessidadeEspecial = false;
            items = new List<KitItem>();
            criancas = new List<Crianca>();
        }

        public Kit(int intCodigo) : this()
        {
            codigo = intCodigo;
            descricao = string.Empty;
            idadeMinima = 0;
            idadeMaxima = 0;
            sexo = string.Empty;
            necessidadeEspecial = false;
            items = new List<KitItem>();
            criancas = new List<Crianca>();
        }

        public Kit(int pCodigo, string pDescricao, 
                   float pIdadeMinima, float pIdadeMaxima, 
                   string pSexo, bool pNecessidadeEspecial) : this()
        {
            codigo = pCodigo;
            descricao = pDescricao;
            idadeMinima = pIdadeMinima;
            idadeMaxima = pIdadeMaxima;
            sexo = pSexo;
            necessidadeEspecial = pNecessidadeEspecial;
            items = new List<KitItem>();
            criancas = new List<Crianca>();
        }

        #endregion

        private int codigo;
        private string descricao;
        private float idadeMinima;
        private float idadeMaxima;
        private string sexo;
        private string sexoDesc;
        private bool necessidadeEspecial;
        private IList<KitItem> items;
        private IList<Crianca> criancas;


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
        public virtual bool NecessidadeEspecial
        {
            get
            {
                return necessidadeEspecial;
            }
            set
            {
                necessidadeEspecial = value;
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


    }
}

using System;
using System.Collections.Generic;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Presenca : IEntidade
    {

        #region "Construtor"

        public Presenca() 
        {
            codigo = 0;
        }

        public Presenca(int intFamilia, int intReuniao) : this()
        {
            familia.Codigo = intFamilia;
            reuniao.Codigo = intReuniao;
        }
        #endregion

        private int codigo;
        private Familia familia;
        private Reuniao reuniao;

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

        public virtual Reuniao Reuniao
        {
            get
            {
                return reuniao;
            }
            set
            {
                reuniao = value;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class FamiliaFake : IEntidade
    {
        public FamiliaFake()
        {
            familia = new Familia();
            codigo = 0;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.DTO
{
    public class DTOPresenca
    {
        public DTOPresenca( )
        {
            familia = 0;
            reuniao = 0;
        }
        public DTOPresenca(int intFamilia, int intReuniao) : this()
        {
            familia = intFamilia;
            reuniao = intReuniao;
        }

        private int familia;
        private int reuniao;

        public virtual int Familia
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

        public virtual int Reuniao
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

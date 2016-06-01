using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jack.DTO
{
    public class DTOCriancas
    {
        public DTOCriancas()
        {
            familia = 0;
            criancas = new List<DTOCrianca>();
        }
        private int familia;
        private List<DTOCrianca> criancas;


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

        public virtual List<DTOCrianca> Criancas {get; set;}

    }

}
using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class Presenca : BaseModel<Presenca>
    {

        #region "Construtor"

        public Presenca() :base()
        {
            familia = new Familia();
            reuniao = new Reuniao();
        }

        #endregion

        private Familia familia;
        private Reuniao reuniao;

        private List<Familia> familias;
        private List<Reuniao> reunioes;

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

        public virtual List<Familia> Familias
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

        public virtual List<Reuniao> Reunioes
        {
            get
            {
                return reunioes;
            }
            set
            {
                reunioes = value;
            }
        }


    }
}

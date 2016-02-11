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

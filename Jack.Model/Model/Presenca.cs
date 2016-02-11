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
            familia = new List<Familia>();
            reuniao = new List<Reuniao>();
        }

        #endregion

        private List<Familia> familia;
        private List<Reuniao> reuniao;

        public virtual List<Familia> Familia
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
        public virtual List<Reuniao> Reuniao
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

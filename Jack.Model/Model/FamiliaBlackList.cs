using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    public class FamiliaBlackList : BaseModel<FamiliaBlackList>
    {
        private Familia familia;
        private int anoFalta;

        public Familia Familia
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
        public int AnoFalta
        {
            get
            {
                return anoFalta;
            }
            set
            {
                anoFalta = value;
            }
        }

    }
}

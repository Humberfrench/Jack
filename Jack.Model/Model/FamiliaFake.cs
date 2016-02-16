using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    public class FamiliaFake : BaseModel<FamiliaFake>
    {
        public FamiliaFake()
        {
            familia = new Familia();
            base.Codigo = 0;
        }

        private Familia familia;

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
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Roupa: BaseModel<Roupa>
    {


        public Roupa()
        {
            Codigo = 0;
            tamanho = string.Empty;
            idade = 0;
            medidaIdade = string.Empty;

        }

        private string tamanho;
        private int idade;
        private string medidaIdade;

        public virtual string Tamanho
        {
            get
            {
                return tamanho;
            }
            set
            {
                tamanho = value;
            }
        }

        public virtual int Idade
        {
            get
            {
                return idade;
            }
            set
            {
                idade = value;
            }
        }

        public virtual string MedidaIdade
        {
            get
            {
                return medidaIdade;
            }
            set
            {
                medidaIdade = value;
            }
        }

        public virtual string IdadeString
        {
            get
            {
                if (MedidaIdade == "M")
                {
                    return Idade.ToString() + " meses";
                }
                else {
                    return Idade.ToString() + " anos";
                }
            }
        }

    }

}

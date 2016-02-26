using System;

namespace Jack.Model
{
    [Serializable()]
    public class Calcado : BaseModel<Calcado>
    {
        private int numero;
        private string sexo;
        private int numeroInicio;
        private int numeroFim; 
        private string medidaIdade;

        public Calcado()
        {
            numero = 0;
            sexo = string.Empty;
            numeroFim = 0;
            numeroInicio = 0;
            medidaIdade = string.Empty;

        }


        public virtual int Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        public virtual string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public virtual int NumeroInicio
        {
            get
            {
                return numeroInicio;
            }
            set
            {
                numeroInicio = value;
            }
        }

        public virtual int NumeroFim
        {
            get
            {
                return numeroFim;
            }
            set
            {
                numeroFim = value;
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

        public virtual string IdadeInicial
        {
            get
            {
                if (MedidaIdade == "M")
                {
                    return NumeroInicio.ToString() + " meses";
                }
                else {
                    return NumeroInicio.ToString() + " anos";
                }
            }
        }

        public virtual string IdadeFinal
        {
            get
            {
                if (MedidaIdade == "M")
                {
                    return NumeroFim.ToString() + " meses";
                }
                else {
                    return NumeroFim.ToString() + " anos";
                }
            }
        }

        public virtual string SexoDescricao
        {
            get
            {
                if (Sexo == "M")
                {
                    return "<span style='color:MidnightBlue;'>Masculino</span>";
                }
                else {
                    return "<span style='color:Red;'>Feminino</span>";
                }
            }
        }

    }
}

using System;

namespace Jack.Model
{
    [Serializable()]
    public class Calcado
    {


        public Calcado()
        {
            Codigo = 0;
            Numero = 0;
            Sexo = string.Empty;
            NumeroInicio = 0;
            NumeroFim = 0;
            MedidaIdade = string.Empty;

        }

        public virtual int Codigo { get; set; }
        public virtual int Numero { get; set; }
        public virtual string Sexo { get; set; }
        public virtual int NumeroInicio { get; set; }
        public virtual int NumeroFim { get; set; }
        public virtual string MedidaIdade { get; set; }

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

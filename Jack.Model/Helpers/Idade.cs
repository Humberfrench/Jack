using System;

namespace Jack.Model.Helpers
{
    public class Idade
    {
        public int Dias { get; }
        public int Meses { get; }
        public int Anos { get; }

        public Idade()
        {

        }
        public Idade(DateTime dataNascimento) : this(dataNascimento, DateTime.Now)
        {

        }
        public Idade(DateTime dataNascimento, DateTime dataDesejada) : this()
        {
            if (dataNascimento > dataDesejada)
            {
                return;
            }

            int dias = dataDesejada.Day - dataNascimento.Day;
            if (dias < 0)
            {
                dataDesejada = dataDesejada.AddMonths(-1);
                dias += DateTime.DaysInMonth(dataDesejada.Year, dataDesejada.Month);
            }

            int meses = dataDesejada.Month - dataNascimento.Month;
            if (meses < 0)
            {
                dataDesejada = dataDesejada.AddYears(-1);
                meses += 12;
            }

            int anos = dataDesejada.Year - dataNascimento.Year;

            Dias = dias;
            Meses = meses;
            Anos = anos;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Extensions
{
    public class Idade
    {
        public int Dias { get; }
        public int Meses { get; }
        public int Anos { get; }

        public Idade()
        {

        }

        public Idade(DateTime dataNascimento) : this()
        {
            if (dataNascimento > DateTime.Now)
            {
                return;
            }

            DateTime hoje = DateTime.Today;

            int dias = hoje.Day - dataNascimento.Day;
            if (dias < 0)
            {
                hoje = hoje.AddMonths(-1);
                dias += DateTime.DaysInMonth(hoje.Year, hoje.Month);
            }

            int meses = hoje.Month - dataNascimento.Month;
            if (meses < 0)
            {
                hoje = hoje.AddYears(-1);
                meses += 12;
            }

            int anos = hoje.Year - dataNascimento.Year;

            Dias = dias;
            Meses = meses;
            Anos = anos;
        }

    }
}

using Jack.DomainValidator;
using System;

namespace Jack.Domain.Helpers
{
    public class Idade
    {
        public int Dias { get; set; }
        public int Meses { get;  set;}
        public int Anos { get;  set;}
        public ValidationResult ValidationResult  { get;  set;}

        public Idade(DateTime dataNascimento) : this(dataNascimento, DateTime.Now)
        {

        }
        public Idade(DateTime dataNascimento, DateTime dataAtual) 
        {
            if (dataNascimento > dataAtual)
            {
                ValidationResult.Add("Data Atual é menor que a Data de Nascimento inserida.");
                return;
            }

            int dias = dataAtual.Day - dataNascimento.Day;
            if (dias < 0)
            {
                dataAtual = dataAtual.AddMonths(-1);
                dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
            }

            int meses = dataAtual.Month - dataNascimento.Month;
            if (meses < 0)
            {
                dataAtual = dataAtual.AddYears(-1);
                meses += 12;
            }

            int anos = dataAtual.Year - dataNascimento.Year;

            Dias = dias;
            Meses = meses;
            Anos = anos;
        }



    }
}

using System;

namespace Jack.Extensions
{
    public static class ConvertExtentions
    {
        public static short ToShort(this string valor)
        {
            short retorno = 0;
            short.TryParse(valor, out retorno);
            return retorno;
        }

        public static Int32 ToInt(this string valor)
        {
            var retorno = 0;
            int.TryParse(valor, out retorno);
            return retorno;
        }

        public static long ToLong(this string valor)
        {
            long retorno = 0;
            long.TryParse(valor, out retorno);
            return retorno;
        }

        public static double ToDouble(this string valor)
        {
            double retorno = 0;
            double.TryParse(valor, out retorno);
            return retorno;
        }
        public static double ToDouble(this decimal? valor)
        {
            if (!valor.HasValue)
            {
                return 0;
            }

            double retorno;
            try
            {
                retorno = Convert.ToDouble(valor);
            }
            catch (Exception)
            {
                retorno = 0;
            }

            return retorno;
        }
        public static double ToDouble(this decimal valor)
        {
            double retorno;
            try
            {
                retorno = Convert.ToDouble(valor);
            }
            catch (Exception)
            {
                retorno = 0;
            }

            return retorno;
        }


        public static DateTime ToDate(this string valor)
        {
            var data = DateTime.Now;
            DateTime.TryParse(valor, out data);
            return data;
        }

    }
}
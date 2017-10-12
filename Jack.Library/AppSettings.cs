namespace Jack.Library
{
    using Extensions;
    using System.Configuration;

    public static class AppSettings
    {
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static bool GetBoolean(string key)
        {
            var valor = ConfigurationManager.AppSettings[key];
            if (valor.IsNullOrEmptyOrWhiteSpace())
            {
                return false;
            }
            if (valor.ToLower() == "true")
            {
                return true;
            }
            return false;
        }
        public static int GetInt(string key)
        {

            var valor = ConfigurationManager.AppSettings[key];
            var retorno = 0;

            int.TryParse(valor, out retorno);

            return retorno;

        }
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
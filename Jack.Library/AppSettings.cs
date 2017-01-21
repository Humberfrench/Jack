namespace Jack.Library
{
    using System;
    using System.ComponentModel;
    using System.Configuration;

    public static class AppSettings
    {
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
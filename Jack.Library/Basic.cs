using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Jack.Library.Extensions
{
    public static class Basic
    {

        public static string ToJSON<T>(this List<T> obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static T JsonToObject<T>(this string obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return (T)serializer.Deserialize<T>(obj);
        }

        public static string ExceptionTratada(this Exception ex)
        {
            string mensagem = null;
            try
            {
                mensagem = ex.Message.ToString();
            }
            catch (Exception generatedExceptionName)
            {
                return generatedExceptionName.Message;
            }
            return mensagem;

        }

        public static bool IsNumeric(this string text)
        {
            try
            {
                Convert.ToInt32(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Jack.Extensions
{
    public static class Basic
    {
        public static string ToJson<T>(this List<T> obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJson(this object obj)
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

        public static string ToMedidaIdade(this string text)
        {
            if (text == "A")
            {
                return "Anos";
            }
            return "Meses";
        }

        public static bool IsNumeric2(this string text)
        {
            try
            {
                var inteiro = Convert.ToInt32(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsNumeric(this string text)
        {
            var numero = 0;
            return int.TryParse(text, out numero);
        }

        public static string ToDateFormated(this DateTime dateValue)
        {
            return dateValue.ToString("dd/MM/yyyy");
        }

        public static string ToAnsiDate(this DateTime dateValue)
        {
            return dateValue.ToString("yyyyMMdd");
        }

        public static string ToTimeFormated(this DateTime dateValue)
        {
            return dateValue.ToString("HH:mm");
        }

        public static string ToDateTimeFormated(this DateTime dateValue)
        {
            return string.Format("{0} | {1}", dateValue.ToString("dd/MM/yyyy"), dateValue.ToString("HH:mm"));
        }

        public static string ToDateTimeFormated(this DateTime dateValue, string separador)
        {
            return string.Format("{0} {1} {2}", dateValue.ToString("dd/MM/yyyy"), separador, dateValue.ToString("HH:mm"));
        }

        public static string ToDateFormated(this DateTime? dateValue)
        {
            if (dateValue.HasValue)
            {
                return dateValue.Value.ToString("dd/MM/yyyy");
            }
            return "";
        }

        public static string ToSaudacao(this DateTime dateValue)
        {
            string saudacao = default(string);
            if (dateValue.Hour >= 0 && dateValue.Hour < 12)
            {
                saudacao = "Bom dia";
            }
            else if (dateValue.Hour >= 12 && dateValue.Hour < 18)
            {
                saudacao = "Boa tarde";
            }
            else if (dateValue.Hour >= 18)
            {
                saudacao = "Boa noite";
            }

            return saudacao;
        }

        public static string ToTimeFormated(this DateTime? dateValue)
        {
            if (dateValue.HasValue)
            {
                return dateValue.Value.ToString("HH:mm");
            }
            return "";
        }

        public static string ToDateTimeFormated(this DateTime? dateValue)
        {
            if (dateValue.HasValue)
            {
                return string.Format("{0} | {1}", dateValue.Value.ToString("dd/MM/yyyy"), dateValue.Value.ToString("HH:mm"));
            }
            return "";
        }

        public static string ToDateTimeFormated(this DateTime? dateValue, string separador)
        {
            if (dateValue.HasValue)
            {
                return string.Format("{0} {1} {2}", dateValue.Value.ToString("dd/MM/yyyy"), separador, dateValue.Value.ToString("HH:mm"));
            }
            return "";
        }

        public static string ToSimNao(this string stringValue)
        {
            if (stringValue == "S")
            {
                return "Sim";
            }
            return "Não";
        }

        public static string ToSimNao(this bool boolValue)
        {
            if (boolValue)
            {
                return "Sim";
            }
            return "Não";
        }

        public static string ToParente(this bool boolValue)
        {
            if (boolValue)
            {
                return "É parente";
            }
            return "Sem Parentesco";
        }

        public static string ToGrauParentesco(this int boolValue)
        {
            switch (boolValue)
            {
                case 1:
                    return "Primeiro Grau";
                case 2:
                    return "Segundo Grau";
                case 3:
                    return "Não é Parente";
                default:
                    return "Nenhum";
            }
        }

        public static string ToSimNaoIcone(this bool boolValue)
        {
            if (boolValue)
            {
                return @"<i class='glyphicon glyphicon-ok-circle'></i>";
            }
            return @"<i class='glyphicon glyphicon-remove-circle'></i>";
        }

        public static string ToSexo(this string stringValue)
        {
            if (stringValue == "F")
            {
                return "Menina";
            }
            else if (stringValue == "M")
            {
                return "Menino";
            }
            else
            {
                return "Indefinido";
            }
        }

        public static string ToNivel(this string stringValue)
        {
            if (stringValue == "F")
            {
                return "Família";
            }
            else if (stringValue == "C")
            {
                return "Criança";
            }
            else
            {
                return "Todos";
            }
        }

        public static int Int(this Enum enumer)
        {
            return Convert.ToInt32(enumer);
        }

        /// <summary>
        /// transforma a primeira letra e a primeira letra apos white-space em maiuscula, 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String ToCapitalize(this String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var formattedText = new StringBuilder();
            var arWords = text.ToLower().Split(' ');

            foreach (String word in arWords)
            {
                if (word.Trim().Length == 0)
                {
                    continue;
                }

                if (formattedText.Length > 0)
                {
                    formattedText.Append(" ");
                }

                String capLetter = word[0].ToString().ToUpper();

                formattedText.Append(capLetter);

                if (word.Length > 1)
                {
                    formattedText.Append(word.Substring(1));
                }
            }

            return formattedText.ToString();
        }

        /// <summary>
        /// Método para retirar acentos e espaço de uma string.
        /// </summary>
        /// <param name="text">Texto a ser fotrmatado</param>
        /// <returns>Texto sem acento</returns>                    
        public static String RemoveAccent(this String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            string[] arCharacter = {"á","é","í","ó","ú","à","ã","õ","â","ê","î","ô","û","ä","ë","ï","ö","ü","ç",
                                     "Á","É","Í","Ó","Ú","À","Ã","Õ","Â","Ê","Î","Ô","Û","Ä","Ë","Ï","Ö","Ü","Ç"};

            string[] arNewCharacter = {"a","e","i","o","u","a","a","o","a","e","i","o","u","a","e","i","o","u","c",
                                        "A","E","I","O","U","A","A","O","A","E","I","O","U","A","E","I","O","U","C"};

            for (int i = 0; i < arCharacter.Length; i++)
            {
                text = text.Replace(arCharacter[i], arNewCharacter[i]);
            }

            return text;
        }

        public static String IsValidEmail(this string strIn)
        {
            //Retorna o e-mail quando valido
            var result = Regex.IsMatch(strIn,
                  @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            return (result) ? strIn : string.Empty;
        }

        /// <summary>
        /// Método para retirar caracteres especiais de uma string
        /// </summary>
        /// <param name="text">Texto a ser fotrmatado</param>
        /// <returns>Texto sem caracteres especiais</returns>                    
        public static String RemoveSpecialCharacter(this String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            //regex para encontrar qualquer coisa exceto letras, acentuadas, numeros
            Regex rgx = new Regex(@"[^\w]");

            //tudo vira hifen
            string strReturn = rgx.Replace(text, "-");

            //removo hifens repetidos seguidos
            strReturn = strReturn.MergeRepeatedCharacters('-');

            return strReturn;
        }

        public static String MergeRepeatedCharacters(this string text, char repeatedChar)
        {
            var reducedString = Regex.Replace(text, repeatedChar + "+", repeatedChar.ToString());
            var finalString = reducedString.Trim(repeatedChar);

            return finalString;
        }

        public static String ToAlphaNumeric(this String text)
        {
            return text.RemoveAccent().RemoveSpecialCharacter();
        }

        public static string FormatoCpfouCnpj(this string text)
        {
            //CNPJ
            if (text.Length == 14)
                return Convert.ToUInt64(text).ToString(@"00\.000\.000\/0000\-00");

            //CPF
            if (text.Length == 11)
                return Convert.ToUInt64(text).ToString(@"000\.000\.000\-00");

            return text;
        }

        public static bool IsDate(this string date, string format = "dd/MM/yyyy")
        {
            DateTime parsedDate;

            var isValidDate = DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

            return isValidDate;
        }

        /// <summary>
        /// converte uma lista de string em uma string separadas por separadores
        /// </summary>
        /// <param name="list">lista</param>
        /// <param name="separator">separador inicial</param>
        /// <param name="lastSeparator">separador do ultimo item</param>
        /// <returns></returns>
        public static string ToGrammarianText(this List<string> list, string separator, string lastSeparator)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            string format = string.Join("{0}", list.ToArray());

            string result;

            if (list.Count > 2)
                result = string.Format(format.ReplaceLastOccurrence("{0}", "{1}"), separator, lastSeparator);
            else
                result = string.Format(format, lastSeparator);

            return result;
        }

        /// <summary>
        /// converte uma lista de string em uma string separadas por virgula e pela preposicao E
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToGrammarianText(this List<string> list)
        {
            return list.ToGrammarianText(", ", " e ");
        }

        public static string ToGrammarianText(this IEnumerable<string> list)
        {
            return list.ToList().ToGrammarianText(", ", " e ");
        }

        /// <summary>
        /// replace na ultima ocorrencia somente
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldString"></param>
        /// <param name="newString"></param>
        /// <returns></returns>
        public static string ReplaceLastOccurrence(this string text, string oldString, string newString)
        {
            int index = text.LastIndexOf(oldString);
            string result = text.Remove(index, oldString.Length).Insert(index, newString);
            return result;
        }

        public static string GetFirstAndLastName(this string name)
        {

            string[] names = name.Split(' ');
            return string.Format("{0} {1}", names.First(), names.Last());

        }

        public static string GetFirstName(this string name)
        {
            var names = name.Split(' ');
            return $"{names.First()}";

        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
        public static bool Preenchido(this string value)
        {
            return !value.IsNullOrEmptyOrWhiteSpace();
        }

        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool ToBoolean(this int value)
        {
            return (value == 1);
        }

        public static string FormatarTelefone(this string telefone, string ddd)
        {
            return $"{ddd}-{telefone}";
        }
        public static string FormatarTelefone(this string telefone, string ddi, string ddd)
        {
            return $"({ddi}) {ddd}-{telefone}";
        }

        public static bool Compare(this string valor, string destino)
        {
            return string.Compare(valor, destino, StringComparison.OrdinalIgnoreCase) == 0;
        }

    }
}
using System;

namespace Jack.DomainValidator
{
    [Serializable]
    public class ValidationError
    {
        public ValidationError(string message)
        {
            this.Message = message;
            this.Erro = true;
        }
        public ValidationError(string message, bool erro)
        {
            this.Message = message;
            this.Erro = erro;
        }

        public string Message { get; set; }
        public bool Erro { get; set; }
    }
}


using System;

namespace Jack.DomainValidator
{
    [Serializable]
    public class ValidationError
    {
        public ValidationError(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}


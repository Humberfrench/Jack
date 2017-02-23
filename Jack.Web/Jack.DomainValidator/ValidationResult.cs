using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jack.DomainValidator
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public void Add(ValidationError error)
        {
            this.errors.Add(error);
        }

        public void Add(params ValidationResult[] validationResults)
        {
            if (validationResults != null)
            {
                foreach (var result in from result in validationResults
                                       where result != null
                                       select result)
                {
                    this.errors.AddRange(result.errors);
                }
            }
        }

        public void Add(string error, bool erro = true)
        {
            var validationErro = new ValidationError(error, erro);
            this.errors.Add(validationErro);
        }

        public void AddError(string error)
        {
            var validationErro = new ValidationError(error,true);
            this.errors.Add(validationErro);
        }

        public void AddWarning(string error)
        {
            var validationErro = new ValidationError(error, false);
            this.errors.Add(validationErro);
        }

        public void Remove(ValidationError error)
        {
            if (this.errors.Contains(error))
            {
                this.errors.Remove(error);
            }
        }

        public IEnumerable<ValidationError> Erros { get { return this.errors; } }

        public bool IsValid
        {
            get
            {
                return this.errors.Any(vr => vr.Erro);
            }
        }

        public string Message { get; set; }

        public bool ProblemaDeInfraestrutura { get; set; }

        public bool Warning
        {
            get
            {
                return this.errors.Count(vr => vr.Erro) != this.Erros.Count();
            }
        }
    }
}


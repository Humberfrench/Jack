using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.DomainValidator
{
    [Serializable]
    public class ValidationResult : IDisposable
    {
        private readonly List<ValidationError> errors;

        public ValidationResult()
        {
            errors = new List<ValidationError>();
        }

        public void Add(ValidationError error) => errors.Add(error);

        public void Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return;
            foreach (var result in from result in validationResults
                                   where result != null
                                   select result)
            {
                this.errors.AddRange(result.errors);
            }
        }

        public void Add(string error, bool erro = true)
        {
            var validationErro = new ValidationError(error, erro);
            this.errors.Add(validationErro);
        }
        public void Add(int codigo, string error, bool erro = true)
        {
            var validationErro = new ValidationError(codigo, error, erro);
            this.errors.Add(validationErro);
        }

        public void AddError(string error)
        {
            var validationErro = new ValidationError(error, true);
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

        public IList<ValidationError> Erros => errors;

        public IList<ValidationError> AllErrors => errors.Where(e => e.Erro).ToList();

        public IList<ValidationError> Warnings => errors.Where(e => !e.Erro).ToList();

        public bool IsValid => !errors.Any(vr => vr.Erro);

        public string Messagem { get; set; }

        public int CodigoMessagem { get; set; }

        public object Retorno { get; set; }

        public bool ProblemaDeInfraestrutura { get; set; }

        public bool Warning => this.errors.Count(vr => vr.Erro) != this.Erros.Count();

        public void Dispose() => GC.SuppressFinalize(this);

    }
}


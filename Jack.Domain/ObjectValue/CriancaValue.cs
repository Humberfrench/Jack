using System;

namespace Jack.Domain.ObjectValue
{
    public class CriancaValue
    {
        public DateTime DataNascimento { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public bool CadastroNovo { get; set; }
        public int Status { get; set; }
        public bool ProcessaStatus { get; set; }
        public bool NescessidadeEspecial { get; set; }
        public bool CriancaGrande { get; set; }
        public bool MoralCrista { get; set; }
        public virtual int Calcado { get; set; }
        public virtual string Roupa { get; set; }
    }
}
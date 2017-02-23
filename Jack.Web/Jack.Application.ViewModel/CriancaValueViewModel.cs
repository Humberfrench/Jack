using System;

namespace Jack.Application.ViewModel
{
    public class CriancaValueViewModel
    {
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public bool CadastroNovo { get; set; }
        public bool NescessidadeEspecial { get; set; } 
        public bool CriancaGrande { get; set; }
        public virtual int Calcado { get; set; }
        public virtual string Roupa { get; set; }
    }
}
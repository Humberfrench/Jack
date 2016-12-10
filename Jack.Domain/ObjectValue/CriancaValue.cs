using System;

namespace Jack.Domain.ObjectValue
{
    public class CriancaValue
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public bool CadastroNovo { get; set; }
        public bool NescessidadeEspecial { get; set; }
        public bool CriancaGrande { get; set; }
    }
}
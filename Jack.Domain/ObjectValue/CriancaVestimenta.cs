
namespace Jack.Domain.ObjectValue
{
    public class CriancaVestimenta
    {
        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual int TipoParentescoId { get; set; }
        public virtual string TipoParentesco { get; set; }
        public virtual string Familia { get; set; }
        public virtual int Idade { get; set; }
        public virtual string MedidaIdade { get; set; }
        public virtual string Sexo { get; set; }
        public virtual int Calcado { get; set; }
        public virtual string Roupa { get; set; }
        public virtual int CalcadoPadrao { get; set; }
        public virtual string RoupaPadrao { get; set; }
        public virtual bool NecessidadeEspecial { get; set; }
        public virtual bool CriancaGrande { get; set; }
        public virtual string IdadeNominal { get; set; }
        public virtual string IdadeNominalReduzida { get; set; }
        public virtual string Status { get; set; }
        public virtual bool PermiteSacola { get; set; }
    }
}



namespace Jack.Model
{
    public class ProcessaPresenca
    {

        public virtual int CodigoFamilia { get; set; }
        public virtual string NomedaMae { get; set; }
        public virtual int NumeroReunioes { get; set; }
        public virtual int TotalReunioes { get; set; }
        public virtual double PercentualReunioes { get; set; }
        public virtual string IsSacolinha { get; set; }

        public virtual string Nivel
        {
            get { return "Nivel " + NumeroNivel.ToString(); }
        }

        public virtual int NumeroNivel { get; set; }

    }

}

namespace Jack.Application.ViewModel
{
    public class ParametroViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual int IdadeLimite { get; set; }
        public virtual int IdadeLimiteExcecao { get; set; }
        public virtual bool TemIdadeLimiteExcecao { get; set; }
        public virtual int CalcadoLimite { get; set; }
        public virtual int NumeroMaximoCricancas { get; set; }
        public virtual int NumeroMaximoRepresentantes { get; set; }
        public virtual int PrimeiroSabado { get; set; }
        public virtual int SegundoSabado { get; set; }
        public virtual int TerceiroSabado { get; set; }
        public virtual int AnoCorrente { get; set; }
        public virtual bool PodeGerarNovasSacolas { get; set; }
        public virtual bool AjusteAutomaticoNoProcessamento { get; set; }
                               
    }
}
using System;

namespace Jack.Domain.ObjectValue
{
    public class QuantidadeSacolasColaborador
    {

        public int Codigo { get; set; }
        public string Nome { get; set; }
        int QuantidadeTotalSacolas { get; set; }
        int QuantidadeSacolas { get; set; }
        double PercentualSacolas { get; set; }
        int QuantidadeSacolasGeradas { get; set; }
        double PercentualSacolasDoTotal { get; set; }
        int QuantidadeSacolasLivres { get; set; }

    }
}
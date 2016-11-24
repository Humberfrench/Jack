
namespace Jack.Application.ViewModel
{
    public class SacolaViewModel
    {

        public int Codigo { get; set; }
        public int SacolaFamilia { get; set; }
        public FamiliaViewModel Familia { get; set; }
        public FamiliaViewModel FamiliaRepresentante { get; set; }
        public CriancaViewModel Crianca { get; set; }
        public string Sexo { get; set; }
        public KitViewModel Kit { get; set; }
        public NivelViewModel Nivel { get; set; }
        public bool Impressa { get; set; }
        public bool Liberado { get; set; }

    }
}
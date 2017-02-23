
namespace Jack.Application.ViewModel
{
    public class PresencaJustificadaViewModel
    {

        public virtual int Codigo { get; set; }
        public FamiliaViewModel Familia { get; set; }
        public bool Ativo { get; set; }
    }
}

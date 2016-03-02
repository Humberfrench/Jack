using Jack.Library.Extensions;

namespace Jack.Model.DTOs
{
    public class DTOStatus : BaseDTO
    {
        public DTOStatus() :base()
        {
            permiteSacola = string.Empty;
            nivelStatus = string.Empty;
        }

        private string permiteSacola;
        private string nivelStatus;
        private string permiteSacolaDesc;
        private string nivelStatusDesc;

        public string PermiteSacola
        {
            get
            {
                return permiteSacola;
            }
            set
            {
                permiteSacola = value;
                permiteSacolaDesc = permiteSacola.ToSimNao();
            }
        }

        public string NivelStatus
        {
            get
            {
                return nivelStatus;
            }
            set
            {
                nivelStatus = value;
                nivelStatusDesc = nivelStatus.ToNivel();
            }
        }
        public string PermiteSacolaDesc
        {
            get
            {
                return permiteSacolaDesc;
            }
        }

        public virtual string NivelStatusDesc
        {
            get
            {
                return nivelStatusDesc;
            }
        }

    }
}

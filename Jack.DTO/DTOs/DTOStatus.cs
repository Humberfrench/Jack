using Jack.Library.Extensions;



namespace Jack.DTO
{
    public class DTOStatus 
    {
        public DTOStatus()
        {
            codigo = 0;
            descricao = string.Empty;
            permiteSacola = string.Empty;
            nivelStatus = string.Empty;
        }

        protected DTOStatus(int pCodigo, string pDescricao) :this()
        {
            codigo = pCodigo;
            descricao = pDescricao;
        }
        private int codigo;
        private string descricao;
        private string permiteSacola;
        private string nivelStatus;
        private string permiteSacolaDesc;
        private string nivelStatusDesc;

        public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }
        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }

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
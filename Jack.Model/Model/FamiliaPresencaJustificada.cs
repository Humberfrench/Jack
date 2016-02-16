namespace Jack.Model
{
    public class FamiliaPresencaJustificada : BaseModel<FamiliaPresencaJustificada>
    {
        public FamiliaPresencaJustificada()
        {
            familia = new Familia();
            isAtivo = "N";
        }

        private Familia familia;
        private string isAtivo;

        public Familia Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }

        public string IsAtivo
        {
            get
            {
                return isAtivo;
            }
            set
            {
                isAtivo = value;
            }
        }

    }
}

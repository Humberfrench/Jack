using System;

namespace Jack.Model
{
    [Serializable()]
    public class ColaboradorCrianca
    {

        #region "Construtor"

        public ColaboradorCrianca()
        {
            Crianca = new Criancas();
            Colaborador = new Colaborador();
        }


        #endregion

        public virtual int Codigo { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public virtual Criancas Crianca { get; set; }
        public virtual int Ano { get; set; }
        public virtual int NumeroSacola { get; set; }
        public virtual string IsDevolvida { get; set; }
        public virtual string NomeCrianca { get; set; }
        public virtual string NomeColaborador { get; set; }

        public virtual int NumeroIdade { get; set; }
        public virtual string MedidaIdade { get; set; }

        public virtual int Calcado { get; set; }
        public virtual string Roupa { get; set; }

        public virtual string Idade
        {
            get
            {
                if (MedidaIdade == "A")
                {
                    return NumeroIdade.ToString() + " Anos";
                }
                else {
                    return NumeroIdade.ToString() + " Meses";
                }
            }
        }

    }
}

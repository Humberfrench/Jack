using System;

namespace Jack.Application.ViewModel
{
    public class ColaboradorCriancaViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual ColaboradorViewModel Colaborador { get; set; }
        public virtual CriancaViewModel Crianca { get; set; }
        public virtual int Ano { get; set; }
        public virtual bool Devolvida { get; set; }
        public virtual DateTime DataCriacao { get; set; }

    }
}

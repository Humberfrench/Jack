using System;
using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class ColaboradorViewModel 
    {

        public virtual IList<ColaboradorCriancaViewModel> Criancas { get; set; }
        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Celular { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Email { get; set; }
        public virtual int AnoNotificacao { get; set; }

    }
}

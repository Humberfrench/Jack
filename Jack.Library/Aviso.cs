using System;
using System.Collections.Generic;

namespace Jack.Library
{
        [Serializable]
        public class Aviso
        {
            public List<string> Mensagens { get; set; }

            public Tipo TipoMensagem { get; set; }

            public string TituloMensagem { get; set; }

            public string Mensagem
            {
                get
                {
                    return String.Join(", ", this.Mensagens);
                }

            }

            public List<string> FieldAlerts { get; set; }

            public enum Tipo
            {
                Atencao, Sucesso, Informacao, Erro
            }

            public Aviso()
            {
                this.FieldAlerts = new List<string>();
                this.Mensagens = new List<string>();
            }

            public Aviso(string mensagem)
                : this(mensagem, Tipo.Erro)
            {

            }

            public Aviso(string mensagem, Tipo tipoMensagem)
                : this()
            {
                this.TipoMensagem = tipoMensagem;
                this.Mensagens.Add(mensagem);
            }
        }
 
}
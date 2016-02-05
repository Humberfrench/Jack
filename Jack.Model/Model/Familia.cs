using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Familia
    {

        #region "Construtor"

        public Familia()
        {
            Codigo = 0;
            Nome = string.Empty;
        }

        #endregion

        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string IsSacolinha { get; set; }
        public virtual string IsConsistente { get; set; }
        public virtual string Contato { get; set; }
        public virtual int Nivel { get; set; }
        public virtual Status Status { get; set; }
        public virtual List<Reuniao> Reuniao { get; set; }
        public virtual List<FamiliaCrianca> Criancas { get; set; }

        public virtual DateTime DataAtualizacao { get; set; }

        public virtual int StatusCodigo
        {
            get { return Status.Codigo; }
        }
        public virtual string StatusNome
        {
            get { return Status.Descricao; }
        }
        public virtual string DataAtualizacaoString
        {
            get { return DataAtualizacao.ToShortDateString(); }
        }

        public virtual string DataFormated
        {
            get { return DataAtualizacao.Day.ToString("00") + "/" + DataAtualizacao.Month.ToString("00") + "/" + DataAtualizacao.Year.ToString("0000"); }
        }
        public virtual string Sacolinha
        {
            get
            {
                if (IsSacolinha == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

 
        public virtual string Consistente
        {
            get
            {
                if (IsConsistente == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

    }
}

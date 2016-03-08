using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    public class Responsavel : BaseModel<Responsavel>
    {

        private string responsavel1;
        private string responsavel2;
        private string documento;
        private string endereco;
        private string bairro;
        private string cep;
        private string cidade;
        private string uf;
        private string telefone;
        private string celular1;
        private string celular2;
        private IList<CriancaMoralCrista> criancas;

        public virtual string Responsavel1
        {
            get
            {
                return responsavel1;
            }
            set
            {
                responsavel1 = value;
            }
        }
        public virtual string Responsavel2
        {
            get
            {
                return responsavel2;
            }
            set
            {
                responsavel2 = value;
            }
        }
        public virtual string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                documento = value;
            }
        }
        public virtual string Endereco
        {
            get
            {
                return endereco;
            }
            set
            {
                endereco = value;
            }
        }
        public virtual string Bairro
        {
            get
            {
                return bairro;
            }
            set
            {
                bairro = value;
            }
        }
        public virtual string Cep
        {
            get
            {
                return cep;
            }
            set
            {
                cep = value;
            }
        }
        public virtual string Cidade
        {
            get
            {
                return cidade;
            }
            set
            {
                cidade = value;
            }
        }
        public virtual string Uf
        {
            get
            {
                return uf;
            }
            set
            {
                uf = value;
            }
        }
        public virtual string Telefone
        {
            get
            {
                return telefone;
            }
            set
            {
                telefone = value;
            }
        }
        public virtual string Celular1
        {
            get
            {
                return celular1;
            }
            set
            {
                celular1 = value;
            }
        }
        public virtual string Celular2
        {
            get
            {
                return celular2;
            }
            set
            {
                celular2 = value;
            }
        }
        public virtual IList<CriancaMoralCrista> Criancas
        {
            get
            {
                return criancas;
            }
            set
            {
                criancas = value;
            }
        }

    }
}

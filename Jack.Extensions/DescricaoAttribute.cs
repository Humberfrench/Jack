using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Extensions
{
    public class DescricaoAttribute : Attribute
    {
        private string _descricao;
        private string _valorReal;

        private int _id;

        public DescricaoAttribute()
        {
        }

        public DescricaoAttribute(string descricao)
        {
            this.Descricao = descricao;
        }

        public DescricaoAttribute(string descricao, string valorReal)
        {
            this.Descricao = descricao;
            this.ValorReal = valorReal;
        }
        public DescricaoAttribute(int id, string descricao, string valorReal)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.ValorReal = valorReal;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public string ValorReal
        {
            get { return _valorReal; }
            set { _valorReal = value; }
        }

        public override string ToString()
        {
            return _descricao;
        }
    }
}

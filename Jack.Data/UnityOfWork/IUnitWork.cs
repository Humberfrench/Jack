using Jack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Data
{
    public interface IUnitWork
    {
        void BeginTransaction();
        void Commit();
        void Salvar(IEntidade entidade);
        void Excluir(IEntidade entidade);
    }
}

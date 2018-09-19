using Jack.Domain.Interfaces;
using System;

namespace Jack.Repository.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Salvar(IEntidade entidade);
        void Excluir(IEntidade entidade);
    }
}

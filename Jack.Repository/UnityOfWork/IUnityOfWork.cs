﻿using Jack.Domain.Interfaces;

namespace Jack.Repository.UnityOfWork
{
    public interface IUnityOfWork
    {
        void BeginTransaction();
        void Commit();
        void Salvar(IEntidade entidade);
        void Excluir(IEntidade entidade);
    }
}

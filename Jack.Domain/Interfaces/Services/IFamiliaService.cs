﻿using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IFamiliaService : IServiceBase<Familia>
    {
        IEnumerable<Familia> ObterNaoSacolas();
        IEnumerable<Familia> ObterTodosTratamento();
        IEnumerable<Familia> ObterPorStatus(int status);
        IEnumerable<Familia> Filtrar(string nome);
        string ObterRepresentante(int familiaId);
        ValidationResult Gravar(Familia entity);
        ValidationResult Gravar(Familia entity, int reuniao);
        ValidationResult Excluir(int id);
        void AtualizarFamilias();
        Familia AtualizarFamilia(Familia familia, bool gravar = true);
        ValidationResult AtualizarFamilia(int id, bool gravar = true);
        void AtualizaNivel(ref Familia familia);
        ValidationResult AtualizarPresencas(Familia familia);
        IEnumerable<Familia> ObterFamiliasBanidas();
        ValidationResult AtualizarFamiliaParaBanida(int familiaId);
        ValidationResult LiberarFamiliaBanida(int familiaId);
        ValidationResult AtualizarSimSacola(int familiaId);
        ValidationResult AtualizarFamiliaComPresencaParaRepresentantes(int id, bool gravar = true);
    }
}
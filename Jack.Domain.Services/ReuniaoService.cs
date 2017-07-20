using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using Jack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class ReuniaoService : ServiceBase<Reuniao>, IReuniaoService
    {

        private readonly IReuniaoRepository repReuniao;
        private readonly IParametroRepository repParametros;
        private readonly IFeriadoRepository repFeriado;
        private readonly ValidationResult validationResult = new ValidationResult();
        private readonly Parametro parametros;

        public ReuniaoService(IReuniaoRepository repReuniao,
                              IParametroRepository repParametros,
                              IFeriadoRepository repFeriado)
            : base(repReuniao)
        {
            this.repReuniao = repReuniao;
            this.repParametros = repParametros;
            this.repFeriado = repFeriado;

            parametros = repParametros.Obter();
        }
        public ValidationResult Gravar(Reuniao item)
        {
            var podeGravar = !repReuniao.ExisteData(item.Data);

            if (!podeGravar)
            {
                validationResult.Add(string.Format("Já existe reunião para a data {0}", item.Data));
                return validationResult;
            }
            
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                Atualizar(item);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repReuniao.Excluir(item);

            return validationResult;

        }

        public ValidationResult MontarDataReuniao(int ano)
        {
            var anoAntes = ano - 1;
            if (parametros == null)
            {
                validationResult.Add("Problemas ao carregar parametros");    
                return validationResult;
            }
            var datas = new List<DatasReuniao>();

            InserirPrimeiraVarredura(anoAntes, ref datas);

            InserirSegundaVarredura(ano, ref datas);

            var datasReuniaoEfetivas = ObterDatasEfetivas(datas, parametros);
            
            // inserir as reunioes
            foreach (var dataReuniao in datasReuniaoEfetivas)
            {
               
                var podeGravar = PodeGravar(ano, dataReuniao);
                
                if (!podeGravar)
                {
                    validationResult.Add(string.Format("Data {0} não pode ser adicionada, é feriado ou tem feriado próximo.", dataReuniao.ToDateFormated()));
                    continue;
                }

                podeGravar = !repReuniao.ExisteData(dataReuniao);

                if (!podeGravar)
                {
                    validationResult.Add(string.Format("Data {0} já cadastrada na Base.", dataReuniao.ToDateFormated()));
                    continue;
                }


                var reuniao = new Reuniao
                {
                    Codigo = 0,
                    AnoCorrente = ano,
                    Ano = dataReuniao.Year,
                    Data = dataReuniao
                };
                Adicionar(reuniao);
            }
            return validationResult;
        }

        private bool PodeGravar(int ano, DateTime dataReuniao)
        {
            var feriado = repFeriado.ObterFeriado(dataReuniao);
            //verifica se pode gravar, se ferido é null pode gravar, 
            //se existe feriado na data da reunião, 
            //precisa verificar se proximo da data tem, 
            //tipo quinta, sexta, segunda e terça -1 e -2 , +2 e +3 na data, 
            //mas o indicador TemReuniao diz que pode ter, então pode gravar
            // encontrado.
            if (feriado != null)
            {
                return feriado.PodeTerReuniao;
            }

            //ver o antes e o depois.
            feriado = repFeriado.ObterFeriadoAntesOuDepois(dataReuniao);
            if (feriado != null)
            {
                return feriado.PodeTerReuniao;
            }

            return true;
        }

        public IEnumerable<Reuniao> ObterReunioesNoAno()
        {
            return repReuniao.ObterTodos().Where(r => r.AnoCorrente == parametros.AnoCorrente);
        }

        public IEnumerable<Reuniao> ObterReunioesNoAno(int ano)
        {
            return repReuniao.ObterTodos().Where(r => r.AnoCorrente == ano);
        }

        private void InserirPrimeiraVarredura(int anoAntes, ref List<DatasReuniao> datas)
        {
            //primeira varredura
            for (var mes = 8; mes <= 12; mes++)
            {
                var dataReuniao = new DatasReuniao
                {
                    Ano = anoAntes,
                    Mes = mes
                };
                for (int dia = 1; dia <= 31; dia++)
                {
                    if (((mes == 9) || (mes == 11)) && (dia == 31))
                    {
                        break;
                    }
                    var data = new DateTime(anoAntes, mes, dia);
                    if (data.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dataReuniao.Datas.Add(data);
                    }
                }
                datas.Add(dataReuniao);
            }

        }

        private void InserirSegundaVarredura(int ano, ref List<DatasReuniao> datas)
        {
            //segunda varredura
            for (var mes = 1; mes <= 7; mes++)
            {
                var dataReuniao = new DatasReuniao
                {
                    Ano = ano,
                    Mes = mes
                };
                for (int dia = 1; dia <= 31; dia++)
                {
                    if (((mes == 4) || (mes == 6)) && (dia == 31))
                    {
                        break;
                    }
                    //fevereiro, pensar no bisexto.
                    if ((mes == 2) && (dia > 28))
                    {
                        break;
                    }
                    var data = new DateTime(ano, mes, dia);
                    if (data.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dataReuniao.Datas.Add(data);
                    }
                }
                datas.Add(dataReuniao);
            }

        }

        private List<DateTime>ObterDatasEfetivas(List<DatasReuniao> datas, Parametro param)
        {
            var primeiroSabado = param.PrimeiroSabado > 0;
            var segundoSabado = param.SegundoSabado > 0;
            var terceiroSabado = param.TerceiroSabado > 0;
            var datasReuniaoEfetivas = new List<DateTime>();

            foreach (var dataReuniao in datas)
            {
                if (primeiroSabado)
                {
                    datasReuniaoEfetivas.Add(dataReuniao.Datas[param.PrimeiroSabado - 1]);
                }
                if (segundoSabado)
                {
                    datasReuniaoEfetivas.Add(dataReuniao.Datas[param.SegundoSabado - 1]);
                }
                if (terceiroSabado)
                {
                    datasReuniaoEfetivas.Add(dataReuniao.Datas[param.TerceiroSabado - 1]);
                }
            }

            return datasReuniaoEfetivas;
        }

    }
}
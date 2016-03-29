using FluentNHibernate.Mapping;
using System;

namespace Jack.Repository.Map
{
    class MapCriancaMoralCrista: ClassMap<Model.CriancaMoralCrista>
    {
        public MapCriancaMoralCrista()
        {
            try
            {
                //Table
                Table("tb_crianca_moral_crista");

                //Fields
                Id(x => x.Codigo).Column("id_crianca");
                Map(x => x.CodigoCrianca).Column("id_crianca_sacola");
                Map(x => x.Nome).Column("ds_nome").Not.Nullable();
                Map(x => x.DataNascimento).Column("dt_nasc").Nullable();
                Map(x => x.Sexo).Column("ds_sexo").Nullable();
                Map(x => x.ProblemaSaude).Column("ds_prob_saude").Nullable();
                Map(x => x.Alergia).Column("ds_alergia").Nullable();
                Map(x => x.Tratamento).Column("ds_tratamento").Nullable();
                Map(x => x.Medo).Column("ds_medo").Not.Nullable();
                Map(x => x.IsCalmo).Column("is_calmo").Nullable(); //.Default("99");
                Map(x => x.IsAgitado).Column("is_agitado").Nullable(); //.Default("99");
                Map(x => x.IsNervoso).Column("is_nervoso").Not.Nullable();
                Map(x => x.IsAnsioso).Column("is_ansioso").Not.Nullable();
                Map(x => x.IsTimido).Column("is_timido").Nullable(); //.Default("N");
                Map(x => x.IsMusica).Column("is_musica").Not.Nullable(); //.Default("N");
                Map(x => x.IsDesenho).Column("is_desenho").Not.Nullable(); //.Default("N");
                Map(x => x.IsDanca).Column("is_danca").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.IsPintura).Column("is_pintura").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.IsEscrever).Column("is_escrever").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.IsVerTv).Column("is_ver_tv").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.IsOutros).Column("is_outros").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.Outros).Column("ds_outros").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.Observacao).Column("ds_observacao").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.IsAtivo).Column("is_ativo").Not.Nullable(); //.Default(DateTime.Now.ToString());

                HasManyToMany(x => x.Responsavel).Table("tb_responsavel_crianca")
                                             .ParentKeyColumn("id_crianca")
                                             .ChildKeyColumn("id_responsavel");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

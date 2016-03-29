using FluentNHibernate.Mapping;
using System;

namespace Jack.Repository.Map
{
    class MapCriancas : ClassMap<Model.Criancas>
    {
        public MapCriancas()
        {
            try
            {
                //Table
                Table("tb_crianca");

                //Fields
                Id(x => x.Codigo).Column("id_crianca");
                Map(x => x.Nome).Column("nm_crianca").Not.Nullable();
                Map(x => x.Idade).Column("nr_idade").Nullable();
                Map(x => x.MedidaIdade).Column("ds_medida_idade").Nullable();
                Map(x => x.DataNascimento).Column("dt_nascimento").Nullable();
                Map(x => x.IdadeNominal).Column("ds_idade_nominal").Nullable();
                Map(x => x.IdadeNominalReduzida).Column("ds_idade_nominal_resumido").Nullable();
                Map(x => x.Sexo).Column("ds_sexo").Not.Nullable();
                Map(x => x.Calcado).Column("nr_calcado").Nullable(); //.Default("99");
                Map(x => x.Roupa).Column("nr_roupa").Nullable(); //.Default("99");
                Map(x => x.IsSacolinha).Column("is_sacolinha").Not.Nullable();
                Map(x => x.IsConsistente).Column("is_consistente").Not.Nullable();
                Map(x => x.IsNecessidadeEspecial).Column("is_necessidade_especial").Nullable(); //.Default("N");
                Map(x => x.IsMoralCrista).Column("is_moral_crista").Not.Nullable(); //.Default("N");
                Map(x => x.IsCriancaMaior).Column("is_crianca_maior").Not.Nullable(); //.Default("N");
                Map(x => x.DataCriacao).Column("dt_create").Not.Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.DataAtualizacao).Column("dt_update").Not.Nullable(); //.Default(DateTime.Now.ToString());

                //References
                References(x => x.Status).Column("id_status").Not.Nullable();
                References(x => x.Kit).Column("id_kit").Not.Nullable();

                HasManyToMany<Model.Familia>(x => x.Familia).Table("tb_familia_crianca")
                                             .ParentKeyColumn("id_crianca")
                                             .ChildKeyColumn("id_familia");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

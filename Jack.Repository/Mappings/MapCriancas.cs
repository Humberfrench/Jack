using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapCriancas : ClassMap<Crianca>
    {
        public MapCriancas()
        {
            //Table
            Table("Crianca");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.Idade).Column("Idade").Nullable();
            Map(x => x.MedidaIdade).Column("MedidaIdade").Nullable();
            Map(x => x.DataNascimento).Column("DataNascimento").Nullable();
            Map(x => x.IdadeNominal).Column("IdadeNominal").Nullable();
            Map(x => x.IdadeNominalReduzida).Column("IdadeNominalReduzida").Nullable();
            Map(x => x.Sexo).Column("Sexo").Not.Nullable();
            Map(x => x.Calcado).Column("Calcado").Nullable(); 
            Map(x => x.Roupa).Column("Roupa").Nullable(); 
            Map(x => x.Sacolinha).Column("Sacolinha").Not.Nullable();
            Map(x => x.Consistente).Column("Consistente").Not.Nullable();
            Map(x => x.NecessidadeEspecial).Column("NecessidadeEspecial").Nullable(); 
            Map(x => x.MoralCrista).Column("MoralCrista").Not.Nullable();
            Map(x => x.CriancaGrande).Column("CriancaGrande").Not.Nullable(); 
            Map(x => x.DataCriacao).Column("DataCriacao").Not.Nullable(); 
            Map(x => x.DataAtualizacao).Column("DataAtualizacao").Not.Nullable(); 

            //References
            References(x => x.Familia).Column("Familia").Not.Nullable().Not.LazyLoad(); 
            References(x => x.Kit).Column("Kit").Not.Nullable();
            References(x => x.Status).Column("Status").Not.Nullable().Not.LazyLoad();

            //Has Many
            HasMany(x => x.Colaboradores).KeyColumn("Crianca").Inverse().Not.LazyLoad(); 

        }
    }
}

using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapNivel : ClassMap<Nivel>
    {
        public MapNivel()
        {
            //Table
            Table("Nivel");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.PercentualInicial).Column("PercentualInicial").Not.Nullable();
            Map(x => x.PercentualFinal).Column("PercentualFinal").Not.Nullable();
            Map(x => x.SacolaGarantida).Column("SacolaGarantida").Nullable();
            Map(x => x.ListaDeEspera).Column("ListaDeEspera").Nullable();
            Map(x => x.NuncaGerarSacola).Column("NuncaGerarSacola").Nullable();

            //References 

            //Has Many
            HasMany(x => x.Familias).KeyColumn("Nivel").Inverse().Not.LazyLoad(); ;

        }
    }
}


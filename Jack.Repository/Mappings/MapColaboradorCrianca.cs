using FluentNHibernate.Mapping;
using System;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapColaboradorCrianca : ClassMap<ColaboradorCrianca>
    {
        public MapColaboradorCrianca()
        {
                //Table
                Table("ColaboradorCrianca");
                LazyLoad();

                //Fields
                Id(x => x.Codigo).Column("Codigo");

                Map(x => x.Ano).Column("Ano").Not.Nullable();
                Map(x => x.Devolvida).Column("Devolvida").Not.Nullable();
                Map(x => x.DataCriacao).Column("DataCriacao");

                //HasManyToMany
                References(x => x.Crianca).Column("Crianca").Not.Nullable();
                References(x => x.Colaborador).Column("Colaborador").Not.Nullable();

        }
    }
}

using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapColaboradorCrianca : ClassMap<Model.ColaboradorCrianca>
    {
        public MapColaboradorCrianca()
        {
            //Table
            Table("tb_colaborador_crianca");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Ano).Column("nr_ano").Not.Nullable();
            Map(x => x.IsDevolvida).Column("is_entregue").Not.Nullable();

            //HasManyToMany
            HasManyToMany<Model.ColaboradorCrianca>(x => x.Colaborador).Cascade.All().Table("tb_colaborador");
            HasManyToMany<Model.ColaboradorCrianca>(x => x.Crianca).Cascade.All().Table("tb_crianca");

        }
    }
}

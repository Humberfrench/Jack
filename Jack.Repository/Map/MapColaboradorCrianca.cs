using FluentNHibernate.Mapping;
using System;


namespace Jack.Repository.Map
{
    class MapColaboradorCrianca : ClassMap<Model.ColaboradorCrianca>
    {
        public MapColaboradorCrianca()
        {
            try
            {
                //Table
                Table("tb_colaborador_crianca");

                //Fields
                Id(x => x.Codigo).Column("id_colaborador_crianca");
                Map(x => x.Ano).Column("nr_ano").Not.Nullable();
                Map(x => x.IsDevolvida).Column("is_entregue").Not.Nullable();

                //HasManyToMany
                References(x => x.Crianca).Column("id_crianca").Not.Nullable().Not.LazyLoad();
                References(x => x.Colaborador).Column("id_colaborador").Not.Nullable().Not.LazyLoad();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

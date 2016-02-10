using FluentNHibernate.Mapping;

namespace Jack.Data.Map
{
    class MapFamiliaCrianca : ClassMap<Model.FamiliaCrianca>
    {
        public MapFamiliaCrianca()
        {
            //Table
            Table("tb_familia_crianca");

            //CompositeId
            CompositeId().KeyProperty(x => x.Familia, "id_familia")
                         .KeyProperty(x => x.Crianca, "id_crianca");

            //References
            References(x => x.Crianca).Column("id_crianca");
            References(x => x.Familia).Column("id_familia");

            ////References
            //References(x => x.Status).Column("id_status");

            //HasMany
            //HasMany(x => x.Criancas).Cascade.All().Table("tb_crianca");

        }
    }
}

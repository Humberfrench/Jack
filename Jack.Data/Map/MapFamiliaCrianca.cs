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
            CompositeId().KeyReference(x => x.Familia, "id_familia")
                         .KeyReference(x => x.Crianca, "id_crianca");
            //HasMany
            HasMany<Model.Presenca>(x => x.Criancas).Cascade.All().Table("tb_crianca");

        }
    }
}

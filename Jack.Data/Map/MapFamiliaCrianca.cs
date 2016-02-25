using FluentNHibernate.Mapping;

namespace Jack.Data.Map
{
    class MapFamiliaCrianca : ClassMap<Model.FamiliaCrianca>
    {
        public MapFamiliaCrianca()
        {
            //Table
            Table("tb_familia_crianca");

            //ID
            Id(x => x.Codigo).Column("id_familia_crianca");

            //References
            References(x => x.Crianca).Column("id_crianca").Not.Nullable();
            References(x => x.Familia).Column("id_familia").Not.Nullable();

        }
    }
}

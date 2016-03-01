using FluentNHibernate.Mapping;


namespace Jack.Data.Map
{
    class MapKitItem : ClassMap<Model.KitItem>
    {
        public MapKitItem()
        {
            //Table
            Table("tb_kit_item");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Observacao).Column("ds_observacao").Nullable();
            Map(x => x.Ordem).Column("nr_ordem").Not.Nullable();

            //References
            References(x => x.Kit).Column("id_kit").Not.Nullable();
            References(x => x.TipoItem).Column("id_tipo_item");

        }
    }
}

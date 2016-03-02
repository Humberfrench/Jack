using FluentNHibernate.Mapping;
using System;

namespace Jack.Data.Map
{
    class MapKitItem : ClassMap<Model.KitItem>
    {
        public MapKitItem()
        {
            try
            {
                //Table
                Table("tb_kit_item");

                //Fields
                Id(x => x.Codigo).Column("id_kit_item");
                Map(x => x.Observacao).Column("ds_observacao").Nullable();
                Map(x => x.Ordem).Column("nr_ordem").Not.Nullable();

                //References
                References(x => x.Kit).Column("id_kit").Not.Nullable();
                References(x => x.TipoItem).Column("id_tipo_item").Not.Nullable();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

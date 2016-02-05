using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapTipoItem : ClassMap<Model.TipoItem>
    {
        public MapTipoItem()
        {
            //Table
            Table("tb_tipo_item");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Descricao).Column("ds_tipo_item").Not.Nullable();
            Map(x => x.IsOpcional).Column("is_opcional").Not.Nullable();

            //References

        }
    }
}

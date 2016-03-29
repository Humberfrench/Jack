using FluentNHibernate.Mapping;
using System;

namespace Jack.Repository.Map
{
    class MapStatus : ClassMap<Model.Status>
    {
        public MapStatus()
        {
            try
            {
                //Table
                Table("tb_status");

                //Fields
                Id(x => x.Codigo).Column("id_status");
                Map(x => x.Descricao).Column("ds_status").Not.Nullable();
                Map(x => x.PermiteSacola).Column("is_permite_sacola").Not.Nullable();
                Map(x => x.NivelStatus).Column("ds_nivel_status").Not.Nullable();

                ////References
                HasMany(x => x.Familias).KeyColumn("id_status");
                HasMany(x => x.Criancas).KeyColumn("id_status");
            }
            catch (Exception ex)
            {
                throw ex;
            }

}
    }
}

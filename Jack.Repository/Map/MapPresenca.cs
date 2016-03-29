using FluentNHibernate.Mapping;
using System;

namespace Jack.Repository.Map
{
    class MapPresenca : ClassMap<Model.Presenca>
    {
        public MapPresenca()
        {
            try
            {
                //Table
                Table("tb_familia_presenca");
            
                //Fields
                Id(x => x.Codigo).Column("id_presenca");

                //References
                References(x => x.Familia).Column("id_familia").Not.Nullable();
                References(x => x.Reuniao).Column("id_reuniao").Not.Nullable();

            }
            catch (Exception ex)
            {
                throw ex;
            }


}
    }
}

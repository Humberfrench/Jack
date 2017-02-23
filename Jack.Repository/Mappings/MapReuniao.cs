using FluentNHibernate.Mapping;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapReuniao : ClassMap<Reuniao>
    {
        public MapReuniao()
        {
            //Table
            Table("Reuniao");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Ano).Column("Ano").Not.Nullable();
            Map(x => x.AnoCorrente).Column("AnoCorrente").Not.Nullable();
            Map(x => x.Data).Column("Data").Not.Nullable();


            //Hasmany  ==> REVER
            HasMany(x => x.FamiliaPresenca).KeyColumn("Reuniao").Inverse().Not.LazyLoad(); ;

        }
    }
}

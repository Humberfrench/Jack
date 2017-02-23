using FluentNHibernate.Mapping;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapKit : ClassMap<Kit>
    {
        public MapKit()
        {

            //Table
            Table("Kit");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.IdadeMinima).Column("IdadeMinima").Not.Nullable();
            Map(x => x.IdadeMaxima).Column("IdadeMaxima").Not.Nullable();
            Map(x => x.Sexo).Column("Sexo").Not.Nullable();
            Map(x => x.NecessidadeEspecial).Column("NecessidadeEspecial");

            //References

            //HasMany
            HasMany(x => x.Criancas).KeyColumn("Kit").Inverse().Not.LazyLoad(); ;
            HasMany(x => x.Items).KeyColumn("Kit").Inverse().Not.LazyLoad(); ;



        }
    }
}

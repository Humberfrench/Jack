using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapRepresentante : ClassMap<Representante>
    {
        public MapRepresentante()
        {
            //Table
            Table("Representante");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Ativo).Column("Ativo").Not.Nullable();

            //References
            References(x => x.TipoParentesco).Column("TipoParentesco").Not.Nullable();
            References(x => x.FamiliaRepresentante).Column("FamiliaRepresentante").Not.Nullable();
            References(x => x.FamiliaRepresentada).Column("FamiliaRepresentada").Not.Nullable();

        }
    }
}

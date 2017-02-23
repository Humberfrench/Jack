using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapCalcado : ClassMap<Calcado>
    {
        public MapCalcado()
        {
            //Table
            Table("Calcado");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Numero).Column("Numero").Not.Nullable();
            Map(x => x.Sexo).Column("Sexo").Not.Nullable();
            Map(x => x.Inicio).Column("Inicio").Not.Nullable();
            Map(x => x.Fim).Column("Fim").Not.Nullable();
            Map(x => x.MedidaIdade).Column("MedidaIdade").Nullable();

        }
    }
}


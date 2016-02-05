using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapKit : ClassMap<Model.Kit>
    {
        public MapKit()
        {
            //Table
            Table("tb_kit");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Descricao).Column("ds_kit").Not.Nullable();
            Map(x => x.IdadeMinima).Column("vl_idade_min").Not.Nullable();
            Map(x => x.IdadeMaxima).Column("vl_idade_max").Not.Nullable();
            Map(x => x.Sexo).Column("ds_sexo").Not.Nullable();
            Map(x => x.IsNecessidadeEspecial).Column("is_necessidade_especial").Nullable();
            HasMany(x => x.Items).KeyColumn("id_kit");
            //References

        }
    }
}

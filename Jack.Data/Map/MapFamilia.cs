using FluentNHibernate.Mapping;
using System;

namespace Jack.Data.Map
{
    class MapFamilia: ClassMap<Model.Familia>
    {
        public MapFamilia()
        {
            //Table
            Table("tb_familia");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Nome).Column("nm_mae").Not.Nullable();
            Map(x => x.Nivel).Column("nr_nivel_espera").Not.Nullable();
            Map(x => x.IsSacolinha).Column("is_sacolinha").Not.Nullable();
            Map(x => x.IsConsistente).Column("is_consistente").Not.Nullable();
            Map(x => x.Contato).Column("ds_contato").Nullable();
            Map(x => x.DataAtualizacao).Column("dt_update").Nullable().Default(DateTime.Now.ToString());

            //References
            References(x => x.Status).Column("id_status");

            //Hasmany
            HasMany(x => x.Reunioes).Cascade.AllDeleteOrphan()
                                   .Fetch.Join()
                                   .Inverse().KeyColumn("id_reuniao");
            HasMany(x => x.Criancas).Cascade.AllDeleteOrphan()
                                   .Fetch.Join()
                                   .Inverse().KeyColumn("id_crianca");
        }
    }
}

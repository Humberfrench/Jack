using FluentNHibernate.Mapping;
using System;


namespace Jack.Repository.Map
{
    class MapFamilia: ClassMap<Model.Familia>
    {
        public MapFamilia()
        {
            try
            {
                //Table
                Table("tb_familia");

                //Fields
                Id(x => x.Codigo).Column("id_familia");
                Map(x => x.Nome).Column("nm_mae").Not.Nullable();
                Map(x => x.Nivel).Column("nr_nivel_espera").Not.Nullable();
                Map(x => x.IsSacolinha).Column("is_sacolinha").Not.Nullable();
                Map(x => x.IsConsistente).Column("is_consistente").Not.Nullable();
                Map(x => x.Contato).Column("ds_contato").Nullable();
                Map(x => x.DataAtualizacao).Column("dt_update").Nullable(); //.Default(DateTime.Now.ToString());
                Map(x => x.Status).Column("id_status").Not.Nullable();


                //Hasmany
                HasManyToMany(x => x.Criancas).Table("tb_familia_crianca")
                                             .ParentKeyColumn("id_familia")
                                             .ChildKeyColumn("id_crianca");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
